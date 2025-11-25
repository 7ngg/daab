using Daab.Modules.Identity.Domain;
using Daab.Modules.Identity.Models;
using Daab.SharedKernel;

namespace Daab.Modules.Identity.Database.Repositories;

public class CountryRepository(IdentityContext context)
    : RepositoryBase<Country>(context),
        ICountryRepository
{
}

