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
    public DbSet<Instructor> Instructors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>()
            .HasMany(e => e.Instructors)
            .WithOne()
            .IsRequired();


        base.OnModelCreating(modelBuilder);
    }
}

