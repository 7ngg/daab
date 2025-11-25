using MediatR;

namespace Daab.Modules.ScientistsDirectory.Features.Scientists.GetAll;

public class GetAllScientistsQuery(GetAllScientistsRequest request) : IRequest<GetAllScientistsResponse>
{
    public GetAllScientistsRequest Request { get; } = request;
}
