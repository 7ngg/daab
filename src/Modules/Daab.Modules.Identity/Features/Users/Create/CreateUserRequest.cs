namespace Daab.Modules.Identity.Features.Users.Create;

public record CreateUserRequest(
    string Email,
    string Password,
    string ConfirmPassword,
    string FirstName,
    string LastName,
    string PhotoUrl,
    string CountryId
);

