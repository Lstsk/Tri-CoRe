using System;
namespace TricoApi.Models;

public class School
{
    public Guid SchoolId { get; set; }
    public string? SchoolName { get; set; }
    public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
}

