namespace Daab.Modules.ScientistsDirectory.Features.Scientists.GetAll;

public record ScientistFilterParameters(string FieldOfStudy);

public record PaginationParameters(int Page, int PageSize);

public record GetAllScientistsRequest(
    PaginationParameters PaginationParameters,
    ScientistFilterParameters FilterParameters
);

