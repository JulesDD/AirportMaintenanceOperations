namespace AircraftMaintenanceOperations.Application.Features.Aircraft.Queries.GetAircraft;

public record GetAircraftQuery : IQuery<GetAircraftResult>;
public record GetAircraftResult(IEnumerable<AircraftDto> Aircrafts);