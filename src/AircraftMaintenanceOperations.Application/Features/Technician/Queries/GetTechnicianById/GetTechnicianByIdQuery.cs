namespace AircraftMaintenanceOperations.Application.Features.Technician.Queries.GetTechnicianById;

public record GetTechnicianByIdQuery(Guid Id) : IQuery<GetTechnicianByIdQueryResult>;
public record GetTechnicianByIdQueryResult(TechnicianDto? Technician);
