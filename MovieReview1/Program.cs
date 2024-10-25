using MovieReview.Services;
using MovieReview.Core.Interfaces;
using MovieReview.Services.JSONImplementations;
using MovieReview.Services.SQLServerImplementations;
using System.Diagnostics.Eventing.Reader;
using Moviereview.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IMovieServices, MovieServicesSQL>();
builder.Services.AddTransient<IReviewService, ReviewServicesSQL>();
builder.Services.AddTransient<IMovieReviewRepository, MovieReviewRepository>();

var app = builder.Build();

app.UseExceptionHandler("/error");
app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();

app.MapControllers();

app.Run();
