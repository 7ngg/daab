namespace Daab.Modules.ScientistsDirectory.Models;

public class Scientist
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }

    public ICollection<FieldOfStudy> FieldsOfStudy { get; set; } = Array.Empty<FieldOfStudy>();

    public string? Description { get; set; }
    public string? AcademicTitle { get; set; }

    public ICollection<string> Publications { get; set; } = Array.Empty<string>();
}

