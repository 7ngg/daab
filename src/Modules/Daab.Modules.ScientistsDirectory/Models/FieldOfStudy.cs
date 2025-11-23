namespace Daab.Modules.ScientistsDirectory.Models;

public class FieldOfStudy(string name)
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string Name { get; init; } = name;
}
