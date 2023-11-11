using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace TricoApi.Models;

public class Instructor
{
    public Guid InstructorId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? FullName { get { return (FirstName + " " + LastName); } }
    // ratings

    public ICollection<Course> Courses { get; set; } = new List<Course>();
    [JsonIgnore]
    public School School { get; set; } = null!;
}

