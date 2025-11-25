using Daab.Modules.ScientistsDirectory.Domain;
using MediatR;

namespace Daab.Modules.ScientistsDirectory.Features.Scientists.GetAll;

public class GetAllScientistsQueryHandler(IScientistRepository scientistRepository)
    : IRequestHandler<GetAllScientistsQuery, GetAllScientistsResponse>
{
    public async Task<GetAllScientistsResponse> Handle(
        GetAllScientistsQuery request,
        CancellationToken cancellationToken
    )
    {
        var scientists = await scientistRepository.GetAsync(cancellationToken: cancellationToken);

        return new GetAllScientistsResponse(scientists);
    }
}

