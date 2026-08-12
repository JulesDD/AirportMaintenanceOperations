namespace AircraftMaintenanceOperations.Application.Features.Technician.Queries.GetTechnician;

public record GetTechnicianQuery : IQuery<GetTechnicianResult>;
public record GetTechnicianResult(IEnumerable<TechnicianDto> Technicians);
