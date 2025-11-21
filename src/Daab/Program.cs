using Daab.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddDbContext<DaabContext>(opts => opts.UseSqlite(config.GetConnectionString("local")));

var app = builder.Build();

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<DaabContext>();
context.Database.Migrate();

app.MapGet("/", () => "Hello World!");

app.Run();
