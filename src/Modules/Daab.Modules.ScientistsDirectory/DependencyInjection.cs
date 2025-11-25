using Daab.Modules.ScientistsDirectory.Database;
using Daab.Modules.ScientistsDirectory.Database.Repositories;
using Daab.Modules.ScientistsDirectory.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Daab.Modules.ScientistsDirectory;

public static class DependencyInjection
{
    extension(IHostApplicationBuilder builder)
    {
        public IHostApplicationBuilder AddScientistsDirectory()
        {
            builder.AddPersistence();
            return builder;
        }

        private void AddPersistence()
        {
            var config = builder.Configuration;
            builder.Services.AddDbContext<ScientistsContext>(options =>
                options.UseSqlite(config.GetConnectionString("local"))
            );

            builder.Services.AddScoped<IScientistRepository, ScientistRepository>();
        }
    }

    extension(IHost app)
    {
        public void UseScientistsDirectory()
        {
            using var scope = app.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<ScientistsContext>();

            context.Database.Migrate();
        }
    }
}
