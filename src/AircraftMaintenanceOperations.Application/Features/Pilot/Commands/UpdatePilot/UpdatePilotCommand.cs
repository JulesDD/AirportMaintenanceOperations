namespace AircraftMaintenanceOperations.Application.Features.Pilot.Commands.UpdatePilot;

public record UpdatePilotCommand(
    Guid PilotId,
    string Rank,
    string LicenseNumber) : ICommand<UpdatePilotCommandResult>;
public record UpdatePilotCommandResult(bool IsSuccess);
