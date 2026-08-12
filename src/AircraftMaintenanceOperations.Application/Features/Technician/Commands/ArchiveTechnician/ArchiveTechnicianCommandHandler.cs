namespace AircraftMaintenanceOperations.Application.Features.Technician.Commands.ArchiveTechnician;

public class ArchiveTechnicianCommandHandler(IAircraftMaintenanceDbContext dbContext) : ICommandHandler<ArchiveTechnicianCommand, ArchiveTechnicianCommandResult>
{
    public async Task<ArchiveTechnicianCommandResult> Handle(ArchiveTechnicianCommand command, CancellationToken cancellationToken)
    {
        var technician = await dbContext.Technicians.FirstOrDefaultAsync(t => t.Id == command.TechnicianId,cancellationToken);
        if (technician == null) return new ArchiveTechnicianCommandResult(false);

        technician.Archive();
        await dbContext.SaveChangesAsync(cancellationToken);

        return new ArchiveTechnicianCommandResult(true);
    }
}
