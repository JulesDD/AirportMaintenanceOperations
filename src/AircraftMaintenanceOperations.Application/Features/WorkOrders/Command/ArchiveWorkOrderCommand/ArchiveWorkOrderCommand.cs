namespace AircraftMaintenanceOperations.Application.Features.WorkOrders.Command.ArchiveWorkOrderCommand;

public record ArchiveWorkOrderCommand(Guid WorkOrderId, string LaborNotes) : ICommand<ArchiveWorkOrderResult>;
public record ArchiveWorkOrderResult(bool IsArchived);
