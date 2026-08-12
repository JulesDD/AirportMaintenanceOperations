namespace AircraftMaintenanceOperations.Application.Features.Technician.Queries.GetTechnicianById;

public class GetTechnicianByIdQueryHandler(IAircraftMaintenanceDbContext dbContext) : IQueryHandler<GetTechnicianByIdQuery, GetTechnicianByIdQueryResult>
{
    public async Task<GetTechnicianByIdQueryResult> Handle(GetTechnicianByIdQuery query, CancellationToken cancellationToken)
    {
        var technician = await dbContext.Technicians
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == query.Id, cancellationToken);

        return new GetTechnicianByIdQueryResult(technician == null ? null : new TechnicianDto(
            technician.EmployeeNumber,
            technician.FirstName,
            technician.LastName,
            technician.Email,
            technician.PhoneNumber,
            technician.Status,
            technician.CertificationLevel,
            technician.YearsOfExperience));
    }
}
