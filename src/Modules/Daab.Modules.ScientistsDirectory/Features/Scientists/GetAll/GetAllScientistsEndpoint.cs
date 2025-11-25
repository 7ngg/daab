using FastEndpoints;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Daab.Modules.ScientistsDirectory.Features.Scientists.GetAll;

public class GetAllScientistsEndpoint(IMediator mediator, ILogger<GetAllScientistsEndpoint> logger)
    : EndpointWithoutRequest<GetAllScientistsResponse>
{
    public override void Configure()
    {
        Get("/scientists");
        AllowAnonymous();
    }

    public override async Task HandleAsync(
        CancellationToken cancellationToken
    )
    {
        string? country = Query<string>("country");
        string? fieldOfStudy = Query<string>("fos");
        // var command = new GetAllScientistsQuery();
        // var scientists = await mediator.Send(command, cancellationToken);
        //
        // await Send.OkAsync(new GetAllScientistsResponse(scientists), cancellationToken);
    }
}
