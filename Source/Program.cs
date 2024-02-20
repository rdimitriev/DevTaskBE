global using FastEndpoints;
global using FluentValidation;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder();
builder.Services
    .AddFastEndpoints()
    .AddCors()
    .SwaggerDocument();

var app = builder.Build();
app .UseDefaultExceptionHandler()
    .UseCors()
    .UseFastEndpoints()
    .UseSwaggerGen();

app.Run();

public partial class Program { }
