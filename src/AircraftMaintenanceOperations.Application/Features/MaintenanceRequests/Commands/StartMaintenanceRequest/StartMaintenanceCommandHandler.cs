namespace AircraftMaintenanceOperations.Application.Features.MaintenanceRequests.Commands.StartMaintenanceRequest;

public class StartMaintenanceCommandHandler(IAircraftMaintenanceDbContext dbContext) : ICommandHandler<StartMaintenanceCommand, StartMaintenanceResult>
{
    public async Task<StartMaintenanceResult> Handle(StartMaintenanceCommand command, CancellationToken cancellationToken)
    {
        var mRequest = await dbContext.MaintenanceRequests.FindAsync([command.Id], cancellationToken: cancellationToken);
        if(mRequest is null) return new StartMaintenanceResult(false);

        mRequest.Start();
        await dbContext.SaveChangesAsync(cancellationToken);
        return new StartMaintenanceResult(true);
    }
}
