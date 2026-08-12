namespace AircraftMaintenanceOperations.Application.Features.Technician.Queries.GetTechnician;

public record GetTechnicianQueryhandler(IAircraftMaintenanceDbContext dbContext) : IQueryHandler<GetTechnicianQuery, GetTechnicianResult>
{
    public async Task<GetTechnicianResult> Handle(GetTechnicianQuery query, CancellationToken cancellationToken)
    {
        var technicians = await dbContext.Technicians
            .AsNoTracking()
            .OrderBy(t => t.LastName)
            .Select(t => new TechnicianDto(
                t.EmployeeNumber,
                t.FirstName,
                t.LastName,
                t.Email,
                t.PhoneNumber,
                t.Status,
                t.CertificationLevel,
                t.YearsOfExperience
            ))
            .ToListAsync(cancellationToken);

        return new GetTechnicianResult(technicians);
    }
}
