using System;
using Microsoft.AspNetCore.Mvc;
using TricoApi.Services;
using TricoApi.Context;
using Microsoft.EntityFrameworkCore;
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

	[HttpGet("Courses")]
	public async Task<IActionResult> GetCourses()
	{
		
		return Ok(await _courseContext.Courses.Include(e => e.Instructors)
			.ToListAsync());
	}

	[HttpGet("Scrape")]
	public async Task<IActionResult> ScrapeCourses()
	{
		await _scrapeCourses.Scrape();
		return Ok(
			"Okayyy"
			);
	}
}

