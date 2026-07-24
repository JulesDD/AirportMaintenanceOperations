namespace AircraftMaintenanceOperations.API.Endpoints.Aircraft;

public record CreateAircraftRequest(
    string TailNumber,
    string Manufacturer,
    string Model,
    string SerialNumber,
    int YearOfManufacture
    );

public record ArchiveAircraftRequest(Guid Id);

public record AssignPilotRequest(
    Guid PilotId, Guid AircraftId
    );

public record GetAircraftRequest();
public record GetAircraftByIdRequest(Guid Id);

public record CreateAircraftResponse(Guid Id);
public record GetAircraftResponse(IEnumerable<AircraftDto> Aircraft);
public record GetAircraftByIdResponse(AircraftDto Aircraft);
public record ArchiveAircraftCommandResponse(Guid Id);
public record AssignPilotCommandResponse(Guid Id);


public class AircraftEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/aircraft", async(CreateAircraftRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateAircraftCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<CreateAircraftResponse>();

            return Results.Created($"/api/aircraft/{response.Id}", response);
        })
            .WithName("CreateAircraft")
            .Produces<CreateAircraftResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Creates a new aircraft.")
            .WithDescription("Create Aircraft");

        app.MapGet("/api/aircraft", async(GetAircraftRequest request, ISender sender) =>
        { 
            var query = request.Adapt<GetAircraftQuery>();
            var result = await sender.Send(query);
            var response = result.Adapt<GetAircraftResponse>();
            return Results.Ok(response);
        })
            .WithName("GetAircraft")
            .Produces<GetAircraftResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Gets a list of aircrafts.")
            .WithDescription("Get Aircrafts");

        app.MapGet("/api/aircraft/{id:guid}", async (GetAircraftByIdRequest request, ISender sender) =>
        {
            var query = request.Adapt<GetAircraftByIdQuery>();
            var result = await sender.Send(query);
            var response = result.Adapt<GetAircraftByIdResponse>();
            return Results.Ok(response);
        })
            .WithName("GetAircraftById")
            .Produces<GetAircraftByIdResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Gets aircraft by Id.")
            .WithDescription("Get aircraft by Id.");

        app.MapPatch("/api/aircraft/{id:guid}/archive", async (ArchiveAircraftRequest request, ISender sender) =>
        {
            var command = request.Adapt<ArchiveAircraftCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<ArchiveAircraftCommandResponse>();
            return Results.Ok(response);
        })
            .WithName("ArchiveAircraft")
            .Produces<ArchiveAircraftCommandResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Archive Aircraft.")
            .WithDescription("Archive Aircraft");

        app.MapPatch("/api/aircraft/{id:guid}/assign-pilot", async (AssignPilotRequest request, ISender sender) =>
        {
            var command = request.Adapt<AssignPilotCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<AssignPilotCommandResponse>();
            return Results.Ok(response);
        })
            .WithName("AssignPilot")
            .Produces<AssignPilotCommandResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Assign Pilot.")
            .WithDescription("Assign Pilot");
    }
}
