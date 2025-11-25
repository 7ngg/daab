using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Daab.Modules.Identity.Features.Users.Create;

public class CreateUserEndpoint(IMediator mediator)
    : Endpoint<CreateUserRequest, CreateUserResponse, CreateUserMapper>
{
    public override void Configure()
    {
        Post("users");

        // For now
        AllowAnonymous();
    }

    public override async Task HandleAsync(
        CreateUserRequest req,
        CancellationToken cancellationToken
    )
    {
        var user = Map.ToEntity(req);
        var command = new CreateUserCommand(user);
        var res = await mediator.Send(command, cancellationToken);

        if (res.IsSuccess)
        {
            var u = res.Value;
            await Send.CreatedAtAsync(
                "/users",
                user.Id,
                Map.FromEntity(u),
                true,
                cancellationToken
            );
            return;
        }

        switch (res.Error.Code)
        {
            case StatusCodes.Status404NotFound:
                await Send.ResultAsync(TypedResults.NotFound(res.Error));
                break;
            default:
                await Send.ErrorsAsync(StatusCodes.Status500InternalServerError, cancellationToken);
                break;
        }
    }
}

