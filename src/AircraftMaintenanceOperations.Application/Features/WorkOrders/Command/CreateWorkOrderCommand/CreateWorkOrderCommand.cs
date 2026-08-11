namespace AircraftMaintenanceOperations.Application.Features.WorkOrders.Command.CreateWorkOrderCommand;

public record CreateWorkOrderCommand(
    Guid MaintenanceRequestId,
    Guid AircraftId,
    Guid AssignedTechnicianId,
    MaintenancePriority WorkOrderPriority,
    DateTime EstimatedCompletionDate) : ICommand<CreatedWorkOrderResult>;

public record CreatedWorkOrderResult(Guid Id);
