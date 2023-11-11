using System;
namespace TricoApi.Models.Query;

public class QueryCourses
{
    public string? College { get; set; }
    public int isHigh { get; set; } = -1;
    public string? Distribution { get; set; }
    public int Size { get; set; }
}

