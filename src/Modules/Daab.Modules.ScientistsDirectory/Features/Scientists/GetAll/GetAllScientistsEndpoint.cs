using Daab.Modules.ScientistsDirectory.Domain;
using FastEndpoints;
using MediatR;

namespace Daab.Modules.ScientistsDirectory.Features.Scientists.GetAll;

public class GetAllScientistsEndpoint(IMediator mediator)
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
        // var command = new GetAllScientistsQuery();
        // var scientists = await mediator.Send(command, cancellationToken);
        //
        // await Send.OkAsync(new GetAllScientistsResponse(scientists), cancellationToken);
    }
}
