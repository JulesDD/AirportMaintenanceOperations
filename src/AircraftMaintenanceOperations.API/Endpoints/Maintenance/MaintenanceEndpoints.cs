using AircraftMaintenanceOperations.Application.Features.MaintenanceRequests.Queries.GetMaintenanceQueryById;

namespace AircraftMaintenanceOperations.API.Endpoints.Maintenance;

public record GetMaintenanceParameters(
    string? RequestNumber,
    string? RequestedBy,
    MaintenanceRequestStatus? Status,
    MaintenancePriority? Priority);

public record GetMaintenanceByIdCommand(Guid Id);
public class MaintenanceEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/maintenance").WithTags("Maintenance");

        group.MapPost("/", async(CreateMaintenanceCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return Results.Created($"/api/maintenance/{result.Id}", result);
        })
            .WithName("CreateMaintenance")
            .Produces<CreatedMaintenanceResult>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Creates a new maintenance record.")
            .WithDescription("Create Maintenance");

        group.MapGet("/", async(ISender sender, [AsParameters] GetMaintenanceParameters command) =>
        {
            var result = await sender.Send(new GetMaintenanceRequestsQuery(
                command.RequestNumber,
                command.RequestedBy,
                command.Status,
                command.Priority));
            return Results.Ok(result);
        })
            .WithName("GetMaintenance")
            .Produces<GetMaintenanceResult>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Retrieves all maintenance records.")
            .WithDescription("Get Maintenance");

        group.MapGet("/{id:guid}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetMaintenanceQueryById(id));
            return Results.Ok(result);
        })
            .WithName("GetMaintenanceById")
            .Produces<GetMaintenanceQueryByIdResult>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Retrieves a specific maintenance record.")
            .WithDescription("Get Maintenance by ID");

        group.MapPatch("/{id:guid}", async(Guid id, UpdateMaintenanceCommand command, ISender sender) =>
        {
            var updateCommand = new UpdateMaintenanceCommand(
                id,
                command.RequestNumber,
                command.Title,
                command.AircraftId,
                command.Description,
                command.RequestedDate,
                command.DueDate,
                command.ClosedDate);
            return Results.Ok(await sender.Send(updateCommand));
        })
            .WithName("UpdateMaintenance")
            .Produces<UpdateMaintenanceResult>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Updates an existing maintenance record.")
            .WithDescription("Update Maintenance");

        group.MapDelete("/{id:guid}", async(Guid id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteMaintenanceCommand(id));
            return Results.Ok(result);
        })
            .WithName("DeleteMaintenance")
            .Produces<DeleteMaintenanceResult>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Deletes an existing maintenance record.")
            .WithDescription("Delete Maintenance");

        group.MapPost("/{id:guid}/close", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new CloseMaintenanceCommand(id));
            return Results.Ok(result);
        })
            .WithName("CloseMaintenance")
            .Produces<CloseMaintenanceResult>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Closes an existing maintenance record.")
            .WithDescription("Close Maintenance");

    }
}