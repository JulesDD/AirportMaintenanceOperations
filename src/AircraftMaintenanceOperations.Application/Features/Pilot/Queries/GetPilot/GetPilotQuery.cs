namespace AircraftMaintenanceOperations.Application.Features.Pilot.Queries.GetPilot;

public record GetPilotQuery : IQuery<GetPilotResult>;
public record GetPilotResult(IEnumerable<PilotDto> Pilots);
