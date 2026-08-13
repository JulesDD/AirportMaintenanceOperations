namespace AircraftMaintenanceOperations.Application.Features.WorkOrders.Command.ArchiveWorkOrderCommand;

public class ArchiveWorkOrderCommandHandler(IAircraftMaintenanceDbContext dbContext) : ICommandHandler<ArchiveWorkOrderCommand, ArchiveWorkOrderResult>
{
    public async Task<ArchiveWorkOrderResult> Handle(ArchiveWorkOrderCommand command, CancellationToken cancellationToken)
    {
        var workOrder = await dbContext.WorkOrders.FindAsync([command.WorkOrderId], cancellationToken);
        if (workOrder is null) return new ArchiveWorkOrderResult(false);

        workOrder.ArchiveWorkOrder(command.LaborNotes);

        await dbContext.SaveChangesAsync(cancellationToken);
        return new ArchiveWorkOrderResult(true);
    }
}
