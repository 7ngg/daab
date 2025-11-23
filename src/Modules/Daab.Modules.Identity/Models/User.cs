namespace Daab.Modules.Identity.Models;

public class User(
    string email,
    string passwordHash,
    string firstName,
    string lastName,
    Guid countryId
)
{
    public Guid Id { get; init; } = Guid.CreateVersion7();

    public required string Email { get; set; } = email;
    public required string PasswordHash { get; set; } = passwordHash;

    public required string FirstName { get; set; } = firstName;
    public required string LastName { get; set; } = lastName;

    public string? PhotoUrl { get; set; }

    public Guid CountryId { get; set; } = countryId;
    public Country? Country { get; set; }

    // TODO: Social media

    public string Slug => $"{FirstName}-{LastName}-{Id.ToString().AsSpan()[..5]}";
}

