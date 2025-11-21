using Daab.Models;
using Microsoft.EntityFrameworkCore;

namespace Daab.Database;

public class DaabContext(DbContextOptions<DaabContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; init; }
    public DbSet<Scientist> Scientists { get; init; }
    public DbSet<Country> Countries { get; init; }
    public DbSet<FieldOfStudy> FieldsOfStudy { get; init; }
}
