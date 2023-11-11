using System;
using System.Text.Json.Serialization;
namespace TricoApi.Data;

public record CourseModel
{
    [JsonPropertyName("ID")]
    public string? ID { get; set; } = null;
    [JsonPropertyName("Url")]
    public string? URL { get; set; } = null;
    [JsonPropertyName("Title")]
    public string? Title { get; set; } = null;
    [JsonPropertyName("InstructorInfo")]
    public string? InstructorInfo { get; set; } = null;
    [JsonPropertyName("Instructor")]
    public string? Instructor { get; set; } = null;
    [JsonPropertyName("CourseRecordNumber")]
    public int CourseRecordNumber { get; set; } = 0;
    [JsonPropertyName("Enrollment")]
    public int EnrollmentNumber { get; set; } = 0;
    [JsonPropertyName("Distribution")]
    public string? Distribution { get; set; } = null;
    [JsonPropertyName("Notes")]
    public string? Notes { get; set; } = null;
    [JsonPropertyName("DatesAndTimes")]
    public string? DaysAndTimes { get; set; } = null;
    [JsonPropertyName("Location")]
    public string? Location { get; set; } = null;
}

