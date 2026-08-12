namespace AircraftMaintenanceOperations.Application.Features.Technician.Commands.UpdateTechnician;

public class UpdateTechnicianCommandHandler(IAircraftMaintenanceDbContext dbContext) : ICommandHandler<UpdateTechnicianCommand, UpdateTechnicianCommandResult>
{
    public async Task<UpdateTechnicianCommandResult> Handle(UpdateTechnicianCommand command, CancellationToken cancellationToken)
    {
        var technician = await dbContext.Technicians.FindAsync(new object[] { command.TechnicianId }, cancellationToken);
        if (technician == null) return new UpdateTechnicianCommandResult(false);

        technician.Update(
            command.FirstName,
            command.LastName,
            command.PhoneNumber,
            command.Email,
            command.CertificationLevel,
            command.YearsOfExperience
        );
        await dbContext.SaveChangesAsync(cancellationToken);
        return new UpdateTechnicianCommandResult(true);
    }
}
