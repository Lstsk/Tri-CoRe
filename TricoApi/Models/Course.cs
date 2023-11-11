using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace TricoApi.Models;


public class Course
{
	public Guid CourseId { get; set; }
	public string? ID_COURSE { get; set; }
	public string? URL { get; set; }
	public string? Title { get; set; }
	public int CourseRecordNumber { get; set; }
	public int Enrollment { get; set; }
	public string? Distribution { get; set; }
	public string? Notes { get; set; }
	public string? Schedule { get; set; }
	public string? Location { get; set; }
	[JsonIgnore]
	public Instructor Instructor { get; set; } = null!;
}

