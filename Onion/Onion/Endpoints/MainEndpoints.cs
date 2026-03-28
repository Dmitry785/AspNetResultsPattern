using MediatR;
using Microsoft.AspNetCore.Mvc;
using Onion.Api.Reqiests;
using Onion.Application.Logic.Groups.Create;
using Onion.Application.Logic.Groups.GetAll;
using Onion.Application.Logic.Groups.GetById;

namespace Onion.Api.Endpoints;

public static class MainEndpoints
{
    public static IEndpointRouteBuilder AddMaintEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        var group = routeBuilder.MapGroup("/group");

        group.MapGet("/", async (IMediator mediator, CancellationToken cancellationToken) =>
        {
            var result = await mediator.Send(new GetAllGroupsQuery(), cancellationToken);
            if (result.Failed)
                return Results.BadRequest(result.ErrorMessage);
            return Results.Ok(result.Data);
        }); // /group

        group.MapGet("/{id:guid}", async (Guid id, IMediator mediator, CancellationToken cancellationToken) =>
        {
            var result = await mediator.Send(new GetGroupByIdQuery(id), cancellationToken);
            if (result.Failed)
                return Results.BadRequest(result.ErrorMessage);
            return Results.Ok(result.Data);
        }); // /group/qwer-1234-qwer

        group.MapPost("/create", async ([FromBody] CreateGroupRequest request, IMediator mediator, CancellationToken cancellationToken) =>
        {
            var command = new CreateGroupCommand(request.Name, request.StudentsCount);
            var result = await mediator.Send(command, cancellationToken);
            if (result.Failed)
                return Results.BadRequest(result.ErrorMessage);
            return Results.Ok(result.Data);
        }); // /group/create

        return routeBuilder;
    }
}
