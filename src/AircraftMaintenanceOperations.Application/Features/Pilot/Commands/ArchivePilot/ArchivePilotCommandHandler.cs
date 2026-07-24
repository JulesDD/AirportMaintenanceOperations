namespace AircraftMaintenanceOperations.Application.Features.Pilot.Queries.ArchivePilot;

internal class ArchivePilotCommandHandler(IAircraftMaintenanceDbContext dbContext) : ICommandHandler<ArchivePilotCommand, ArchivePilotCommandResult>
{
    public async Task<ArchivePilotCommandResult> Handle(ArchivePilotCommand command, CancellationToken cancellationToken)
    {
        var pilot = await dbContext.Pilots.FindAsync([command.PilotId], cancellationToken: cancellationToken);
        if (pilot == null) return new ArchivePilotCommandResult(false);

        pilot.Archive();
        await dbContext.SaveChangesAsync(cancellationToken);

        return new ArchivePilotCommandResult(true);
    }
}
