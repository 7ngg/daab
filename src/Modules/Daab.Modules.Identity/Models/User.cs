namespace Daab.Modules.Identity.Models;

public class User(
    string id,
    string email,
    string passwordHash,
    string firstName,
    string lastName,
    string countryId
)
{
    public string Id { get; init; } = id;

    public string Email { get; set; } = email;
    public string PasswordHash { get; set; } = passwordHash;

    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;

    public string? PhotoUrl { get; set; }

    public string CountryId { get; set; } = countryId;
    public Country? Country { get; set; }

    // TODO: Social media

    public string Slug => $"{FirstName}-{LastName}-{Id.AsSpan()[^5..]}";
}

