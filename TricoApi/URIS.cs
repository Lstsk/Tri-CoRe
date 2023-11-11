using System;
namespace TricoApi;

public class URIS
{
    // Spring 2024 Course info for Tri-Co
    public static readonly int SWARTHMORE_PAGE = 22;
    public static readonly int BRYN_MAWR_PAGE = 23;
    public static readonly int HAVERFORD_PAGE = 23;
    public static string GetURL(int pageNum, int school)
    {
        switch (school)
        {
            case 0:
                return $"https://www.swarthmore.edu/tricollege-course-guide/search-results?page={pageNum}&college%5B0%5D=swarthmore&per_page=50&semester%5B0%5D=spring_2024";
            case 1:
                return $"https://www.swarthmore.edu/tricollege-course-guide/search-results?page={pageNum}&college%5B0%5D=swarthmore&per_page=50&semester%5B0%5D=spring_2024";
            case 2:
                return $"https://www.swarthmore.edu/tricollege-course-guide/search-results?page={pageNum}&college%5B0%5D=haverford&per_page=50&semester%5B0%5D=spring_2024";
            default:
                return "";
        }
    }
}


