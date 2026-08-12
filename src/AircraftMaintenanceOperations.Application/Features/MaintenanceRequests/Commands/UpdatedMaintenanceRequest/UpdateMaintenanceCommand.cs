namespace AircraftMaintenanceOperations.Application.Features.MaintenanceRequests.Commands.UpdatedMaintenanceRequest;

public record UpdateMaintenanceCommand
(
    Guid Id,
    string Title,
    string Description,
    DateTime DueDate) : ICommand<UpdateMaintenanceResult>;

public record UpdateMaintenanceResult(bool IsUpdated);