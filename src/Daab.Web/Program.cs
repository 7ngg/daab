using Daab.Modules.Identity;
using Daab.Modules.ScientistsDirectory;
using FastEndpoints;
using Scalar.AspNetCore;
using Serilog;

var logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddSerilog(
        (services, lc) =>
            lc
                .ReadFrom.Configuration(builder.Configuration)
                .ReadFrom.Services(services)
                .Enrich.FromLogContext()
                .WriteTo.Console()
    );

    builder.Services.AddOpenApi();
    builder.Services.AddFastEndpoints();

    builder.AddIdentity();
    builder.AddScientistsDirectory();

    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

    var app = builder.Build();

    app.UseSerilogRequestLogging();
    app.MapFastEndpoints();

    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.MapScalarApiReference();
    }

    app.UseIdentity();
    app.UseScientistsDirectory();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "An unhandled exception occured during bootstrapping");
}
finally
{
    Log.CloseAndFlush();
}
