using System;
using System.Net;
using System.Reflection;
using HtmlAgilityPack;
using System.Text.Json;
using System.Text.Json.Serialization;
using TricoApi.Data;
namespace TricoApi.Services;

public class ScrapeCourses : IScrapeCourses
{
    public string _schoolURL = "https://www.swarthmore.edu";
    public int _page = 0;
	public readonly HttpClient _client;
    public readonly string _path = Environment.CurrentDirectory + "/Data/brynmawr.txt";

	public ScrapeCourses()
	{
		HttpClientHandler handler = new()
		{
			UseProxy = false,
		};
		_client = new(handler);
	}

	public async Task Scrape(int school)
	{

        switch (school)
        {
            case 0:
                _page = URIS.SWARTHMORE_PAGE;
                break;
            case 1:
                _page = URIS.BRYN_MAWR_PAGE;
                break;
            case 2:
                _page = URIS.HAVERFORD_PAGE;
                break;
            case 3:
                Console.WriteLine("Invalid input; Choose between 0, 1, 2");
                return;
        }

        try
        {
            for (int i = 1; i < URIS.SWARTHMORE_PAGE; i++)
            {
		        var res = await _client.GetAsync(URIS.GetURL(i, school));
                await FilterData(await res.Content.ReadAsStringAsync());
            }
        }
        catch {
            Console.WriteLine("error");
        }
			
	}

	public async Task FilterData(string res)
	{
        HtmlDocument htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(res);

        var courseInfo = htmlDoc.DocumentNode.SelectNodes("//tr")
            .Where(e => e.HasClass("odd") || e.HasClass("even"))
            .ToList();

        foreach (var course in courseInfo)
        {
            
            var courseData = new CourseModel();

            var data = course.SelectNodes(".//dt | .//dd");
            if (course.InnerHtml == null)
            {
                break;
            }
            for (int i = 0; i < data.Count; i++)
            {
                var temp = data[i].SelectSingleNode(".//a");
                try
                {
                    switch (data[i].InnerHtml)
                    {
                        case "ID:":
                            temp = data[i + 1].SelectSingleNode(".//a");
                            courseData.ID = temp.InnerText;
                            courseData.URL = (_schoolURL + temp.Attributes["href"].Value).Replace("amp;", "");
                            break;
                        case "Instructor:":
                            temp = data[i + 1].SelectSingleNode(".//a");
                            courseData.Instructor = temp.InnerText;
                            courseData.InstructorInfo = temp.Attributes["href"].Value;
                            if (temp.Attributes["href"].Value.Contains("@"))
                            {
                                courseData.InstructorInfo = temp.Attributes["href"].Value;
                            }
                            else
                            {
                                courseData.InstructorInfo = _schoolURL + temp.Attributes["href"].Value;
                            }

                            break;
                        case "Title:":
                            courseData.Title = data[i + 1].InnerText;
                            break;
                        case "Course Record Number:":
                            courseData.CourseRecordNumber = Int32.Parse(data[i + 1].InnerText);
                            break;
                        case "Enrollment Limit:":
                            courseData.EnrollmentNumber = Int32.Parse(data[i + 1].InnerText);
                            break;
                        case "Distribution:":
                            courseData.Distribution = data[i + 1].InnerText;
                            break;
                        case "Notes:":
                            courseData.Notes = data[i + 1].InnerText;
                            break;
                        case "Days and Times:":
                            temp = data[i + 1].SelectSingleNode(".//span");
                            courseData.DaysAndTimes = temp.InnerText;
                            break;
                        case "Location:":
                            courseData.Location = data[i + 1].InnerText;
                            break;
                    }
                }
                catch
                {
                }
            }
            try
            {
                using (StreamWriter writer = File.AppendText(_path))
                {
                    var serializeOptions = new JsonSerializerOptions
                    {
                        WriteIndented = true,
                        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                    };

                    string result = JsonSerializer.Serialize<CourseModel>(courseData, serializeOptions);
                    await writer.WriteLineAsync(result +",");
                }
            }
            catch
            {
                Console.WriteLine("Error from helper function");
            }
        }
    }
}

