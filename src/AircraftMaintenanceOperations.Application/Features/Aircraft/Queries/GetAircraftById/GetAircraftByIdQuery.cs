namespace AircraftMaintenanceOperations.Application.Features.Aircraft.Queries.GetAircraftById;

public record GetAircraftByIdQuery(Guid AircraftId) : IQuery<GetAircraftByIdResult>;
public record GetAircraftByIdResult(AircraftDto? Aircrafts);