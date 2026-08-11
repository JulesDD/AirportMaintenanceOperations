namespace AircraftMaintenanceOperations.Application.Features.WorkOrders.Command.UpdateWorkOrderCommand;

public record UpdateWorkOrderCommand(
    Guid WorkOrderId,
    string Title,
    string Description,
    MaintenancePriority WorkOrderPriority,
    DateTime EstimatedCompletionDate)
    : ICommand<UpdateWorkOrderResult>;

public record UpdateWorkOrderResult(bool IsUpdated);
