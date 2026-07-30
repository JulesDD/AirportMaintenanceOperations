namespace AircraftMaintenanceOperations.Application.Features.MaintenanceRequests.Commands.DeleteMaintenanceRequest;

public record DeleteMaintenanceCommand(Guid Id) : ICommand<DeleteMaintenanceResult>;

public record DeleteMaintenanceResult(bool IsDeleted);