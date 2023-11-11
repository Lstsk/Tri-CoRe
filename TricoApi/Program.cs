using System;

using TricoApi.Services;
using TricoApi.Data;
using TricoApi.Context;
using Microsoft.EntityFrameworkCore;

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

AppDbInitializer.Seed(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

