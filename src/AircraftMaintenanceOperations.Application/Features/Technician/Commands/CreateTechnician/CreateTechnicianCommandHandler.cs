namespace AircraftMaintenanceOperations.Application.Features.Technician.Commands.CreateTechnician;

public class CreateTechnicianCommandHandler(IAircraftMaintenanceDbContext dbContext) : ICommandHandler<CreateTechnicianCommand, CreateTechnicianCommandResult>
{
    public async Task<CreateTechnicianCommandResult> Handle(CreateTechnicianCommand command, CancellationToken cancellationToken)
    {
        var technician = Domain.Entities.Technician.Create
        (
            command.EmployeeNumber,
            command.FirstName,
            command.LastName,
            command.Email,
            command.PhoneNumber,
            command.CertificationNumber,
            command.YearsOfExperience
        );
        
        dbContext.Technicians.Add(technician);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateTechnicianCommandResult(technician.Id);
    }
}
