namespace Daab.Models;

public class Scientist
{
    public Guid Id { get; init; }

    public Guid UserId { get; init; }
    public User? User { get; init; }

    public ICollection<FieldOfStudy> FieldsOfStudy { get; set; } = Array.Empty<FieldOfStudy>();

    public string? Description { get; set; }
    public string? AcademicTitle { get; set; }

    public List<string> Publications { get; set; } = [];
}
