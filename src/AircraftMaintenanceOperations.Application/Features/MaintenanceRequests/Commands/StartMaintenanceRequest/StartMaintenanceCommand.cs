namespace AircraftMaintenanceOperations.Application.Features.MaintenanceRequests.Commands.StartMaintenanceRequest;

public record StartMaintenanceCommand(Guid Id) : ICommand<StartMaintenanceResult>;
public record StartMaintenanceResult(bool IsStarted);
