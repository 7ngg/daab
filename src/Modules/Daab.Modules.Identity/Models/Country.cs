namespace Daab.Modules.Identity.Models;

public class Country(string id, string name)
{
    public string Id { get; init; } = id;
    public string Name { get; init; } = name;
}
