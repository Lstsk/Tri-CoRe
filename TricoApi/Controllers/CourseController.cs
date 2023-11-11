using System;
using Microsoft.AspNetCore.Mvc;
using TricoApi.Services;
using TricoApi.Context;
using Microsoft.EntityFrameworkCore;
using TricoApi.Models;
using TricoApi.Models.Query;
using TricoApi.Data.Enum;
namespace TricoApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class CourseController:ControllerBase
{
	public readonly CourseContext _courseContext;
	public readonly IScrapeCourses _scrapeCourses;
	public CourseController(CourseContext courseContext, IScrapeCourses scrapeCourses)
	{
		_courseContext = courseContext;
		_scrapeCourses = scrapeCourses;
	}

	[HttpGet("Schools")]
	public async Task<IActionResult> GetSchools()
	{

		return Ok(await
			 _courseContext.Schools
			 .Include(e=> e.Instructors)
				.ThenInclude(e => e.Courses)
			 .ToListAsync()
			 );

	}
	[HttpGet("Instructors")]
	public async Task<IActionResult> GetInstructors()
	{
		return Ok( await
			_courseContext.Instructors
			.Include(e => e.Courses)
			.ToListAsync()
			);
	}

	[HttpGet("Courses")]
	public async Task<IActionResult> GetCourses([FromQuery] QueryCourses query)
	{


		var raqueryResult = query.College is null ? _courseContext.Courses : _courseContext.Schools.Where(e => e.SchoolName == query.College).SelectMany(e => e.Instructors.SelectMany(e => e.Courses)).Where(e => e.Distribution == query.Distribution);


   //     var raqueryResult = _courseContext.Schools
			//.Where(e => e.SchoolName == query.College)
			//.SelectMany(e => e.Instructors
			//	.SelectMany(e => e.Courses))
			//		.Where(e => e.Distribution == query.Distribution);

		if (query.isHigh == 0)
		{
			raqueryResult = raqueryResult
				.OrderBy(e => Guid.NewGuid())
				.OrderByDescending(course => course.Rating)
				.Take(query.Size);
		}
		else if (query.isHigh == 1)
		{
			raqueryResult = raqueryResult
				.OrderBy(e => Guid.NewGuid())
				.OrderBy(course => course.Rating)
				.Take(query.Size);
		}
		else
		{
			raqueryResult = raqueryResult
				.OrderBy(e => Guid.NewGuid())
				.Take(query.Size);
		}



        return Ok(
			await raqueryResult.ToListAsync()
            );
	}
}

