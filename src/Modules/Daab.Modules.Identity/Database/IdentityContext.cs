using Daab.Modules.Identity.Models;
using Microsoft.EntityFrameworkCore;

namespace Daab.Modules.Identity.Database;

public class IdentityContext(DbContextOptions<IdentityContext> options) : DbContext(options)
{
    internal DbSet<Country> Countries { get; set; }
    internal DbSet<User> Users { get; set; }
}
