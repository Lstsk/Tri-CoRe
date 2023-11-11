using System;
using Microsoft.AspNetCore.Mvc;
using TricoApi.Services;
namespace TricoApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class CourseController:ControllerBase
{
	public readonly IScrapeCourses _scrapeCourses;
	public CourseController(IScrapeCourses scrapeCourses)
	{
		_scrapeCourses = scrapeCourses;
	}

	[HttpGet]
	public async Task<IActionResult> GetCourses()
	{
		return Ok("courses");
	}
}

