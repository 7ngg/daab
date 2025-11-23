using Microsoft.EntityFrameworkCore;

namespace Daab.Modules.ScientistsDirectory.Database;

public class ScientistsContext(DbContextOptions<ScientistsContext> options) : DbContext(options)
{
}
