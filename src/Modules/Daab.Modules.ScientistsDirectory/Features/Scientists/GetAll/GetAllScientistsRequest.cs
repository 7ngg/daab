namespace Daab.Modules.ScientistsDirectory.Features.Scientists.GetAll;

public record ScientistFilterParameters(string FieldOfStudy);

public record GetAllScientistsRequest(
    ScientistFilterParameters FilterParameters
);

