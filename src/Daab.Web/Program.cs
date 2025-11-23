using Daab.Modules.ScientistsDirectory;
using Daab.Modules.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.AddScientistsDirectory();
builder.AddIdentity();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
