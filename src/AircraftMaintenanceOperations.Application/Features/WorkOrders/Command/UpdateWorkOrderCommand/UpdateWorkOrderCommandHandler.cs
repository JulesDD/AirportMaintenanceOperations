namespace AircraftMaintenanceOperations.Application.Features.WorkOrders.Command.UpdateWorkOrderCommand;

public class UpdateWorkOrderCommandHandler(IAircraftMaintenanceDbContext dbContext) : ICommandHandler<UpdateWorkOrderCommand, UpdateWorkOrderResult>
{
    public async Task<UpdateWorkOrderResult> Handle(UpdateWorkOrderCommand command, CancellationToken cancellationToken)
    {
        var order = await dbContext.WorkOrders.FindAsync([command.WorkOrderId], cancellationToken);

        if (order is null)
            return new UpdateWorkOrderResult(false);

        order.UpdateDetails(
            command.Title,
            command.Description,
            command.WorkOrderPriority,
            command.EstimatedCompletionDate);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateWorkOrderResult(true);
    }
}
