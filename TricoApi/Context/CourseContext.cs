using System;
using TricoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TricoApi.Context;

public class CourseContext:DbContext
{
	public CourseContext(DbContextOptions<CourseContext> options): base(options)
	{
	}

    public DbSet<Course> Courses { get; set; } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}

