using Daab.Modules.ScientistsDirectory.Models;
using Microsoft.EntityFrameworkCore;

namespace Daab.Modules.ScientistsDirectory.Database;

public class ScientistsContext(DbContextOptions<ScientistsContext> options) : DbContext(options)
{
    public DbSet<Scientist> Scientists { get; init; }
    public DbSet<FieldOfStudy> FieldsOfStudy { get; init; }
}
