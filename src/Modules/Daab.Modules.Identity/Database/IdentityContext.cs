using Daab.Modules.Identity.Models;
using Microsoft.EntityFrameworkCore;

namespace Daab.Modules.Identity.Database;

public class IdentityContext(DbContextOptions<IdentityContext> options) : DbContext(options)
{
    internal DbSet<Country> Countries { get; set; }
    internal DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(user => user.HasIndex(u => u.Email, "user_email_idx"));
        modelBuilder.Entity<Country>(country =>
        {
            country.HasKey(c => c.Id);
            country.HasIndex(c => c.Name, "country_name_idx");
        });
    }
}
