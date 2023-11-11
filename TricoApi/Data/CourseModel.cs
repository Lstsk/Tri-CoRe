using System;
namespace TricoApi.Data;

public record CourseModel
{
    public string? ID { get; set; } = null;
    public string? URL { get; set; } = null;
    public string? Title { get; set; } = null;
    public string? Email { get; set; } = null;
    public string? Instructor { get; set; } = null;
    public int CourseRecordNumber { get; set; } = 0;
    public int EnrollmentNumber { get; set; } = 0;
    public string? Distribution { get; set; } = null;
    public string? Notes { get; set; } = null;
    public string? DaysAndTimes { get; set; } = null;
    public string? Location { get; set; } = null;
}

