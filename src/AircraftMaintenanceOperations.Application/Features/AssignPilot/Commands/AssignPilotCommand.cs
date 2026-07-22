namespace AircraftMaintenanceOperations.Application.Features.AssignPilot.Command;

public record AssignPilotCommand(Guid PilotId, Guid AircraftId) : ICommand<AssignPilotResult>;
public record AssignPilotResult(bool IsSuccess);
