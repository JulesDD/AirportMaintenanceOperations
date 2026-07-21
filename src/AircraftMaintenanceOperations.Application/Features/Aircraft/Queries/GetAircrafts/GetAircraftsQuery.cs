namespace AircraftMaintenanceOperations.Application.Features.Aircraft.Queries.GetAircraft;

public record GetAircraftsQuery : IQuery<GetAircraftsResult>;
public record GetAircraftsResult(IEnumerable<AircraftDto> Aircrafts);
}