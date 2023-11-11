using System;
using System.Data.Entity;

namespace TricoApi.Models;

public class Course
{
	public Guid CourseId { get; set; }
	public string? CourseName { get; set; }
	public DateTime RegistrationStart { get; set; }
	public DateTime RegistrationEnd { get; set; }
	public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
}

