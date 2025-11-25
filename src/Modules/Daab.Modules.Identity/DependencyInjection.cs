using Daab.Modules.Identity.Database;
using Daab.Modules.Identity.Database.Repositories;
using Daab.Modules.Identity.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Daab.Modules.Identity;

public static class DependencyInjection
{
    extension(IHostApplicationBuilder builder)
    {
        public void AddIdentity()
        {
            builder.AddPersistence();
        }

        private void AddPersistence()
        {
            var config = builder.Configuration;
            builder.Services.AddDbContext<IdentityContext>(options =>
                options.UseSqlite(config.GetConnectionString("identity"))
            );

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICountryRepository, CountryRepository>();

            builder.Services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly)
            );
        }
    }

    extension(IHost app)
    {
        public void UseIdentity()
        {
            using var scope = app.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<IdentityContext>();

            context.Database.Migrate();
        }
    }
}
