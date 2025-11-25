using MediatR;
using Daab.Modules.Identity.Models;
using Daab.SharedKernel;

namespace Daab.Modules.Identity.Features.Users.Create;

public class CreateUserCommand(User user) : IRequest<Result<User>>
{
    public User User { get; } = user;
}
