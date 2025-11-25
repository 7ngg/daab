using Daab.Modules.Identity.Domain;
using Daab.Modules.Identity.Models;
using Daab.SharedKernel;

namespace Daab.Modules.Identity.Database.Repositories;

public class UserRepository(IdentityContext context)
    : RepositoryBase<User>(context),
        IUserRepository { }

