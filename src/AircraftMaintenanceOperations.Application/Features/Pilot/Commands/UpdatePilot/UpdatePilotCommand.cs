namespace AircraftMaintenanceOperations.Application.Features.Pilot.Commands.UpdatePilot;

public record UpdatePilotCommand(Guid PilotId) : ICommand<UpdatePilotCommandResult>;
public record UpdatePilotCommandResult(bool IsSuccess);
