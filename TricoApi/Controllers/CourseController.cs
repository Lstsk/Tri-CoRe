using System;
using Microsoft.AspNetCore.Mvc;
namespace TricoApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class CourseController:ControllerBase
{
	public CourseController()
	{
	}

	[HttpGet]
	public async Task<IActionResult> GetCourses()
	{
		return Ok("courses");
	}
}

