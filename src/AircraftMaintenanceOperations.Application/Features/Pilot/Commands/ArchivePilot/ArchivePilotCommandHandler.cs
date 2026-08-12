namespace AircraftMaintenanceOperations.Application.Features.Pilot.Queries.ArchivePilot;

public class ArchivePilotCommandHandler(IAircraftMaintenanceDbContext dbContext) : ICommandHandler<ArchivePilotCommand, ArchivePilotResult>
{
    public async Task<ArchivePilotResult> Handle(ArchivePilotCommand command, CancellationToken cancellationToken)
    {
        var pilot = await dbContext.Pilots.FindAsync([command.PilotId], cancellationToken: cancellationToken);
        if (pilot == null) return new ArchivePilotResult(false);

        pilot.Archive();
        await dbContext.SaveChangesAsync(cancellationToken);

        return new ArchivePilotResult(true);
    }
}
