using System;
using TricoApi.Context;
using TricoApi.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using TricoApi.Data;
namespace TricoApi.Data;

public class AppDbInitializer
{
    public static readonly Guid _swarthmoreId = Guid.NewGuid();
    public static readonly Guid _brynmawrId = Guid.NewGuid();
    public static readonly Guid _haverfordId = Guid.NewGuid();
	public AppDbInitializer()
	{

	}
	public static async void Seed(IApplicationBuilder applicationBuilder)
	{
		using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
		{
            var context = serviceScope.ServiceProvider.GetService<CourseContext>();
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
            if (!context.Schools.Any())
            {
                var swarthmore = new School()
                {
                    SchoolId = _swarthmoreId,
                    SchoolName = "Swarthmore"
                };
                var brynmawr = new School()
                {
                    SchoolId = _brynmawrId,
                    SchoolName = "Bryn Mawr"
                };
                var haverford = new School()
                {
                    SchoolId = _haverfordId,
                    SchoolName = "Haverford"
                };

                context.Schools.Add(swarthmore);
                context.Schools.Add(brynmawr);
                context.Schools.Add(haverford);
                await context.SaveChangesAsync();
            }

            var path = Directory.GetCurrentDirectory() + "/Data" + "/AllTriCoCourses.json";
            string? jsonText;
            using (StreamReader r = new StreamReader(path))
            {
                jsonText = await r.ReadToEndAsync();
                
            }
            var some = JsonSerializer.Deserialize<DeserializeCourse>(jsonText);
            for (int i = 0; i < 3; i++)
            {
                var schoolData = i switch
                {
                    0 => some.Swarthmore,
                    1=>some.BrynMar,
                    2 => some.Haverford
                };

                var InstructorCourseObject = await CreateObject(schoolData);
                var obj = context.Schools.Find(i switch
                    {
                        0 => _swarthmoreId,
                        1 => _brynmawrId,
                        2 => _haverfordId
                    });

                if (obj != null)
                {
                    foreach (var InstructorCourse in InstructorCourseObject)
                    {
                        obj.Instructors.Add(InstructorCourse);
                    }
                await context.SaveChangesAsync();
                }
            }
		}
    }
    private static async Task<List<Instructor>> CreateObject(List<CourseModel> values)
    {
        List<Instructor> InstructorsAndCourses = new List<Instructor>();
        foreach (var value in values)
        {
            var firstName = value.Instructor != null ? value.Instructor.Split(",").Last().Trim() : null;
            var lastName = value.Instructor != null ? value.Instructor.Split(",")[0].Trim() : null;
            var temp = new Instructor()
            {
                InstructorId = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
            };

            var temp2 = new Course()
            {
                CourseId = Guid.NewGuid(),
                ID_COURSE = value.ID,
                URL = value.URL,
                Title = value.Title,
                CourseRecordNumber = value.CourseRecordNumber,
                Enrollment = value.EnrollmentNumber,
                Distribution = value.Distribution,
                Notes = value.Notes,
                Schedule = value.DaysAndTimes,
                Location = value.Location
            };
            temp.Courses.Add(temp2);
            InstructorsAndCourses.Add(temp);
        }
        return InstructorsAndCourses;
    }
}

