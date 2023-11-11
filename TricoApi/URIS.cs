using System;
namespace TricoApi;

public class URIS
{
    // Spring 2024 Course info for Tri-Co
    public static readonly int SWARTHMORE_PAGE = 50;
    public static string SWARTHMORE(int pageNum)
    {
        return $"https://www.swarthmore.edu/tricollege-course-guide/search-results?page={pageNum}&college%5B0%5D=swarthmore&per_page=50&semester%5B0%5D=spring_2024";
    }
    public static readonly string HAVERFORD = "https://www.swarthmore.edu/tricollege-course-guide/search-results?semester%5B0%5D=spring_2024&college%5B0%5D=haverford&per_page=50";
    public static readonly string BRYNMAWR = "https://www.swarthmore.edu/tricollege-course-guide/search-results?semester%5B0%5D=spring_2024&college%5B0%5D=bryn_mawr&per_page=50";
}


