using AircraftMaintenanceOperations.Application.Features.Pilot.Queries.ArchivePilot;

namespace AircraftMaintenanceOperations.API.Endpoints.Pilot;

public record CreatePilotRequest(
    string Rank,
    string LicenseNumber
    );
public record GetPilotRequest();
public record GetPilotByIdRequest(Guid Id);

public record CreatePilotResponse(Guid Id);
public record GetPilotResponse(IEnumerable<PilotDto> Pilot);
public record GetPilotByIdResponse(PilotDto Pilot);

public class PilotEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/pilot", async(CreatePilotRequest request, ISender sender) => 
        {
            var command = request.Adapt<CreatePilotCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<CreatePilotResponse>();

            return Results.Created($"/api/pilot/{response.Id}", response);
        })
            .WithName("CreatePilot")
            .Produces<CreatePilotResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Created a new Pilot.")
            .WithDescription("Create Pilot");

        app.MapGet("/api/pilot", async(GetPilotRequest request, ISender sender) =>
        {
            var query = request.Adapt<GetPilotQuery>();
            var result = await sender.Send(query);
            var respond = result.Adapt<GetPilotResponse>();

            return Results.Ok(respond);
        })
            .WithName("GetPilot")
            .Produces<GetPilotResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Gets a list of Pilots.")
            .WithDescription("Get Pilots");

        app.MapGet("/api/pilot/{id:guid}", async (GetPilotByIdRequest request, ISender sender) =>
        {
            var query = request.Adapt<GetPilotByIdQuery>();
            var result = await sender.Send(query);
            var response = result.Adapt<GetPilotByIdResponse>();
            return Results.Ok(response);
        })
            .WithName("GetPilotById")
            .Produces<GetPilotByIdResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Gets pilot by Id.")
            .WithDescription("Get pilot by Id.");

        app.MapPatch("/api/pilot/{id:guid}/archive", async (ArchivePilotRequest request, ISender sender) =>
        {
            var command = request.Adapt<ArchivePilotRequest>();
            var result = await sender.Send(command);
            var response = result.Adapt<ArchivePilotRequestResult>();
            return Results.Ok(response);
        })
            .WithName("ArchivePilot")
            .Produces<ArchivePilotRequestResult>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Archive Pilot.")
            .WithDescription("Archive Pilot");

        app.MapPut("/api/pilot/{id:guid}", async (UpdatePilotCommand request, ISender sender) =>
        { 
            var command = request.Adapt<UpdatePilotCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<UpdatePilotCommandResult>();
            return Results.Ok(response);
        })
            .WithName("UpdatePilot")
            .Produces<UpdatePilotCommandResult>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Update Pilot.")
            .WithDescription("Update Pilot");
    }
}
