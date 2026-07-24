namespace AircraftMaintenanceOperations.Application.Features.Pilot.Queries.ArchivePilot;

internal class ArchivePilotRequestHandler(IAircraftMaintenanceDbContext dbContext) : ICommandHandler<ArchivePilotRequest, ArchivePilotRequestResult>
{
    public async Task<ArchivePilotRequestResult> Handle(ArchivePilotRequest command, CancellationToken cancellationToken)
    {
        var pilot = await dbContext.Pilots.FindAsync([command.PilotId], cancellationToken: cancellationToken);
        if (pilot == null) return new ArchivePilotRequestResult(false);

        pilot.Archive();
        await dbContext.SaveChangesAsync(cancellationToken);

        return new ArchivePilotRequestResult(true);
    }
}
