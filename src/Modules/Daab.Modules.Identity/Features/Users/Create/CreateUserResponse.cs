namespace Daab.Modules.Identity.Features.Users.Create;

public record CreateUserResponse(
    string Id,
    string Email,
    string FirstName,
    string LastName,
    string? PhotoUrl,
    string Slug,
    string CountryId
);

