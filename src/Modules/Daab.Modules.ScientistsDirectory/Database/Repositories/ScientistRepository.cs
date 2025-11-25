using Daab.Modules.ScientistsDirectory.Domain;
using Daab.Modules.ScientistsDirectory.Models;
using Daab.SharedKernel;

namespace Daab.Modules.ScientistsDirectory.Database.Repositories;

public class ScientistRepository(ScientistsContext context)
    : RepositoryBase<Scientist>(context),
        IScientistRepository { }

