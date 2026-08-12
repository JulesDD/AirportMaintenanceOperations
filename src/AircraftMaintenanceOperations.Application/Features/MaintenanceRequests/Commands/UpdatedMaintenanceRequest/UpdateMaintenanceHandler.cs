namespace AircraftMaintenanceOperations.Application.Features.MaintenanceRequests.Commands.UpdatedMaintenanceRequest;

public class UpdateMaintenanceHandler(IAircraftMaintenanceDbContext dbContext) : ICommandHandler<UpdateMaintenanceCommand, UpdateMaintenanceResult>
{
    public async Task<UpdateMaintenanceResult> Handle(UpdateMaintenanceCommand command, CancellationToken cancellationToken)
    {
        var mRequest = await dbContext.MaintenanceRequests.FindAsync([command.Id], cancellationToken: cancellationToken);
        if (mRequest is null) return new UpdateMaintenanceResult(false);

        mRequest.Update(
            command.Title,
            command.Description,
            command.DueDate);

        await dbContext.SaveChangesAsync(cancellationToken);
        return new UpdateMaintenanceResult(true);
       
        
    }
}
