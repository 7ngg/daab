using Daab.Modules.ScientistsDirectory.Models;

namespace Daab.Modules.ScientistsDirectory.Features.Scientists.GetAll;

public record GetAllScientistsResponse(IEnumerable<Scientist> Scientists);

