using Daab.Modules.ScientistsDirectory.Database;
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
        }
    }
}
