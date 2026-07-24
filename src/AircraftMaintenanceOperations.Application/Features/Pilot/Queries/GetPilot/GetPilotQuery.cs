namespace AircraftMaintenanceOperations.Application.Features.Pilot.Queries.GetPilot;

public record GetPilotQuery : IQuery<GetPilotQueryResult>;
public record GetPilotQueryResult(IEnumerable<PilotDto> Pilots);
