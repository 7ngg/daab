using Daab.Modules.ScientistsDirectory;
using Daab.Modules.Identity;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();

builder.AddIdentity();
builder.AddScientistsDirectory();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();

app.MapFastEndpoints();

app.UseScientistsDirectory();

app.Run();
