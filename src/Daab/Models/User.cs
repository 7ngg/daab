namespace Daab.Models;

public class User
{
    public Guid Id { get; init; }

    public required string Email { get; set; }
    public required string PasswordHash { get; set; }

    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    public string? PhotoUrl { get; set; }

    public Guid CountryId { get; set; }
    public Country? Country { get; set; }

    // TODO: Social media

    public string Slug => $"{FirstName}-{LastName}-{Id.ToString().AsSpan()[..5]}";
}
