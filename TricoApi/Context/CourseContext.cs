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
    public DbSet<School> Schools { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // One-To-Many | School-to-Instructors
        //modelBuilder.Entity<School>()
        //    .HasMany(e => e.Instructors)
        //    .WithOne();
        //    //.HasForeignKey(e => e.InstructorId)
        //    //.IsRequired();

        modelBuilder.Entity<Instructor>()
            .HasOne(e => e.School)
            .WithMany()
            .HasForeignKey(e => e.InstructorId)
            .IsRequired();

        modelBuilder.Entity<Course>()
            .HasOne(e => e.Instructor)
            .WithMany()
            .HasForeignKey(e => e.CourseId)
            .IsRequired();

        // One-To-Many | Instructor - to - Courses
        //modelBuilder.Entity<Instructor>()
        //    .HasMany(e => e.Courses)
        //    .WithOne()
        //    //.HasForeignKey(e => e.CourseId)
        //    .IsRequired();

        base.OnModelCreating(modelBuilder);
    }
    
}

