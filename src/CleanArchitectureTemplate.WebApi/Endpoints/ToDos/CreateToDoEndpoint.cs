using CleanArchitectureTemplate.Application.ToDos.CreateToDo;
using CleanArchitectureTemplate.BuildingBlocks.Exceptions;
using CleanArchitectureTemplate.WebApi.Contracts;

namespace CleanArchitectureTemplate.WebApi.Endpoints.ToDos;

internal static class CreateToDoEndpoint
{
    public static IEndpointRouteBuilder MapCreateToDo(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/api/to-do", async (CreateToDoRequest request, CreateToDoHandler handler, CancellationToken ct) =>
        {
            try
            {
                var result = await handler.HandleAsync(new CreateToDoCommand(request.Title), ct);
                return result.ToHttp();
            }
            catch (DomainException de)
            {

                return Results.Problem(title: "Business rule violation", detail: de.Message, statusCode: StatusCodes.Status400BadRequest);
            }
        });

        return endpoints;
    }

}
