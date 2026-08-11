namespace AircraftMaintenanceOperations.Application.Features.WorkOrders.Command.AssignTechnicianCommand;

public record AssignTechnicianCommand(Guid WorkOrderId, Guid TechnicianId) : ICommand<AssignTechnicianResult>;
public record AssignTechnicianResult(bool IsSuccess, string? Error = null);