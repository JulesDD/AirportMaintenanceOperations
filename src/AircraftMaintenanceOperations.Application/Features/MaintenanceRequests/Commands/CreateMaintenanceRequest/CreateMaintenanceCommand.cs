namespace AircraftMaintenanceOperations.Application.Features.MaintenanceRequests.Commands.CreatedMaintenanceRequest;

public record CreateMaintenanceCommand(
    string Title,
    Guid AircraftId,
    string Description,
    string RequestedBy,
    DateTime DueDate) : ICommand<CreatedMaintenanceResult>;

public record CreatedMaintenanceResult(Guid Id);