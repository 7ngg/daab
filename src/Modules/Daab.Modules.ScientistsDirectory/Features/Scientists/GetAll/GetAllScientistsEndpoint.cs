using Daab.Modules.ScientistsDirectory.Domain;
using FastEndpoints;

namespace Daab.Modules.ScientistsDirectory.Features.Scientists.GetAll;

public class GetAllScientistsEndpoint(IScientistRepository scientistRepository)
    : Endpoint<GetAllScientistsRequest, GetAllScientistsResponse>
{
    public override void Configure()
    {
        Get("/scientists");
        AllowAnonymous();
    }

    public override async Task HandleAsync(
        GetAllScientistsRequest req,
        CancellationToken cancellationToken
    )
    {
        var scientists = await scientistRepository.GetAsync(cancellationToken: cancellationToken);

        await Send.OkAsync(new GetAllScientistsResponse(scientists), cancellationToken);
    }
}
