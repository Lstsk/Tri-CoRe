using System;
namespace TricoApi.Models;

public class Instructor
{
    public Guid InstructorId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? FullName { get { return (FirstName + " " + LastName); } }
    //public List<int> Ratings { get; set; } = new List<int>();
}

