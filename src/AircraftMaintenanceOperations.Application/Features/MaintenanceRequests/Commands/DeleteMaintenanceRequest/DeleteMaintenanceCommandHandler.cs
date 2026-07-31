namespace AircraftMaintenanceOperations.Application.Features.MaintenanceRequests.Commands.DeleteMaintenanceRequest;

public class DeleteMaintenanceCommandHandler(IAircraftMaintenanceDbContext dbContext) : ICommandHandler<DeleteMaintenanceCommand, DeleteMaintenanceResult>
{
    public async Task<DeleteMaintenanceResult> Handle(DeleteMaintenanceCommand command, CancellationToken cancellationToken)
    {
        var mRequest = await dbContext.MaintenanceRequests.FindAsync([command.Id], cancellationToken);
        if(mRequest is null) return new DeleteMaintenanceResult(false);

        dbContext.MaintenanceRequests.Remove(mRequest);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteMaintenanceResult(true);
    }
}
