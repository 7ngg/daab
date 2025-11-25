using Daab.Modules.Identity.Helpers;
using Daab.Modules.Identity.Models;
using FastEndpoints;

namespace Daab.Modules.Identity.Features.Users.Create;

public class CreateUserMapper : Mapper<CreateUserRequest, CreateUserResponse, User>
{
    public override User ToEntity(CreateUserRequest r) =>
        new(
            Guid.NewGuid().ToString(),
            r.Email,
            PasswordHasher.HashPassword(r.Password),
            r.FirstName,
            r.LastName,
            r.CountryId
        );

    public override CreateUserResponse FromEntity(User u) =>
        new(u.Id, u.Email, u.FirstName, u.LastName, u.PhotoUrl, u.Slug, u.CountryId);
}

