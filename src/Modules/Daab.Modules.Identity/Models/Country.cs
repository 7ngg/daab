namespace Daab.Modules.Identity.Models;

public class Country(string name)
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string Name { get; init; } = name;
}
