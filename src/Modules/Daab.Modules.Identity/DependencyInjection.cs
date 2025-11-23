using Daab.Modules.Identity.Database;
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
            var config = builder.Configuration;
            builder.Services.AddDbContext<IdentityContext>(options =>
                options.UseSqlite(config.GetConnectionString("identity"))
            );
        }
    }
}
