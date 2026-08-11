namespace AircraftMaintenanceOperations.Application.Features.MaintenanceRequests.Commands.ArchiveMaintenanceRequest;

public class ArchiveMaintenanceCommandHandler(IAircraftMaintenanceDbContext dbContext) : ICommandHandler<ArchiveMaintenanceCommand, ArchiveMaintenanceResult>
{
    public async Task<ArchiveMaintenanceResult> Handle(ArchiveMaintenanceCommand command, CancellationToken cancellationToken)
    {
        var mRequest = await dbContext.MaintenanceRequests.FindAsync([command.MaintenanceRequestId], cancellationToken);
        if(mRequest is null) return new ArchiveMaintenanceResult(false);

        mRequest.Archive();
        await dbContext.SaveChangesAsync(cancellationToken);

        return new ArchiveMaintenanceResult(true);
    }
}
