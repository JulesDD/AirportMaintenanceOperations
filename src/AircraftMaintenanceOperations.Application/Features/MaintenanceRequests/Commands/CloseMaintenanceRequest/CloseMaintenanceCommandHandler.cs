namespace AircraftMaintenanceOperations.Application.Features.MaintenanceRequests.Commands.CloseMaintenanceRequest;

public class CloseMaintenanceCommandHandler(IAircraftMaintenanceDbContext dbContext) : ICommandHandler<CloseMaintenanceCommand, CloseMaintenanceResult>
{
    public async Task<CloseMaintenanceResult> Handle(CloseMaintenanceCommand command, CancellationToken cancellationToken)
    {
        var mRequest = await dbContext.MaintenanceRequests.FindAsync([command.Id], cancellationToken: cancellationToken);
        if(mRequest is null) return new CloseMaintenanceResult(false);

        mRequest.Closed();
        await dbContext.SaveChangesAsync(cancellationToken);
        return new CloseMaintenanceResult(true);
    }
}
