using TricoApi.Services;
using TricoApi.Context;
using Microsoft.EntityFrameworkCore;

var client = new ScrapeCourses();
await client.Scrape();
//client.QueryBuilder();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IScrapeCourses, ScrapeCourses>();
builder.Services.AddDbContext<CourseContext>(e => e.UseInMemoryDatabase("Course Context"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

