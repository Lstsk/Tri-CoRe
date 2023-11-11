using System;
namespace TricoApi.Services;

public interface IScrapeCourses
{
    Task Scrape(int school);
    Task FilterData(string res);
}

