namespace AircraftMaintenanceOperations.Application.Features.Aircraft.Queries.GetAircraftById;

public record GetAircraftByIdQuery(Guid AircraftId) : IQuery<GetAircraftByIdQueryResult>;
public record GetAircraftByIdQueryResult(AircraftDto? Aircrafts);