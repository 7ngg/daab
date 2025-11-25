using Daab.Modules.Identity.Domain;
using Daab.Modules.Identity.Models;
using Daab.SharedKernel;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Daab.Modules.Identity.Features.Users.Create;

public class CreateUserCommandHandler(
    IUserRepository userRepository,
    ICountryRepository countryRepository
) : IRequestHandler<CreateUserCommand, Result<User>>
{
    public async Task<Result<User>> Handle(
        CreateUserCommand request,
        CancellationToken cancellationToken
    )
    {
        var country = await countryRepository.FindAsync(request.User.CountryId, cancellationToken);

        if (country is null)
        {
            return Error.New(StatusCodes.Status404NotFound, "Requested country does not exist");
        }

        await userRepository.InsertAsync(request.User, cancellationToken);
        await userRepository.SaveChangesAsync(cancellationToken);

        return request.User;
    }
}
