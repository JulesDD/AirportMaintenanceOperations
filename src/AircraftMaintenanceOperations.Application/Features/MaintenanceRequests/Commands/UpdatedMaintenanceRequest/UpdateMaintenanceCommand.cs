namespace AircraftMaintenanceOperations.Application.Features.MaintenanceRequests.Commands.UpdatedMaintenanceRequest;

public record UpdateMaintenanceCommand
(
    Guid Id,
    string RequestNumber,
    string Title,
    Guid AircraftId,
    string Description,
    DateTime DueDate,
    DateTime ClosedDate) : ICommand<UpdateMaintenanceResult>;

public record UpdateMaintenanceResult(bool IsUpdated);