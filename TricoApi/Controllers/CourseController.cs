using System;
using Microsoft.AspNetCore.Mvc;
using TricoApi.Services;
using TricoApi.Context;
using Microsoft.EntityFrameworkCore;
using TricoApi.Models;
using TricoApi.Models.Query;
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
		var queryResult = _courseContext.Courses.Where(e => e.Distribution == query.Distribution).Select(e => e);
		//if (query.Distribution != null)
		//{
		//	queryResult = _courseContext.Courses.Where(e => e.Distribution == query.Distribution).Select(e=> e);
		//}

		

		return Ok(await
			queryResult.Take(query.Size).ToListAsync()
			);
	}
}

