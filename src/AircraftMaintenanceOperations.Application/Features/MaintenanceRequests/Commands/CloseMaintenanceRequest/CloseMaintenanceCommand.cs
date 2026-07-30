namespace AircraftMaintenanceOperations.Application.Features.MaintenanceRequests.Commands.CloseMaintenanceRequest;

public record CloseMaintenanceCommand(Guid Id) : ICommand<CloseMaintenanceResult>;
public record CloseMaintenanceResult(bool IsClosed);
