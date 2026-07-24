namespace AircraftMaintenanceOperations.Application.Features.Pilot.Queries.GetPilotById;

public record GetPilotByIdQuery(Guid PilotId) : IQuery<GetPilotByIdQueryResult>;
public record GetPilotByIdQueryResult(PilotDto Pilot);
