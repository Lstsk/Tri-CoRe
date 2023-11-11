using System;
using System.Net;
using HtmlAgilityPack;
using TricoApi.Data;
namespace TricoApi.Services;

public class ScrapeCourses : IScrapeCourses
{
	public readonly HttpClient _client;
	public ScrapeCourses()
	{
		HttpClientHandler handler = new()
		{
			UseProxy = false,
		};
		_client = new(handler);
	}

	public async Task Scrape()
	{
		Console.WriteLine("test");
			
		var res = await _client.GetAsync(URIS.SWARTHMORE(1));
		var responseString = await res.Content.ReadAsStringAsync();
		HtmlDocument htmlDoc = new HtmlDocument();
		htmlDoc.LoadHtml(responseString);

		var courseInfo = htmlDoc.DocumentNode.SelectNodes("//tr")
			.Where(e => e.HasClass("odd") || e.HasClass("even"))
			.ToList();

		foreach (var course in courseInfo)
		{
			var courseData = new CourseModel();
			var data = course.SelectNodes(".//dt | .//dd");
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
                            courseData.URL = temp.Attributes["href"].Value;
                            break;
                        case "Instructor:":
                            temp = data[i + 1].SelectSingleNode(".//a");
                            courseData.Instructor = temp.InnerText;
                            courseData.Email = temp.Attributes["href"].Value;
                            break;
                        case "Course Record Number:":
                            courseData.CourseRecordNumber = Int32.Parse(data[i+1].InnerText);
                            break;
                        case "Enrollment Limit:":
                            courseData.EnrollmentNumber = Int32.Parse(data[i+1].InnerText);
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
			Console.WriteLine(courseData);
		}

		Console.ReadLine();

	}

	public string QueryBuilder()
	{
		Console.WriteLine(URIS.SWARTHMORE(50));
		return "";
	}
}

