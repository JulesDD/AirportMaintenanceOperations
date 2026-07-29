namespace AircraftMaintenanceOperations.Application.Features.AssignPilot.Command;

public record AssignPilotCommand(Guid AircraftId, Guid PilotId) : ICommand<AssignPilotResult>;
public record AssignPilotResult(bool IsSuccess);
