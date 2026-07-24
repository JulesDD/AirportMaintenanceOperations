namespace AircraftMaintenanceOperations.Application.Features.Aircraft.Queries.GetAircraft;

public record GetAircraftQuery : IQuery<GetAircraftsResult>;
public record GetAircraftsResult(IEnumerable<AircraftDto> Aircrafts);