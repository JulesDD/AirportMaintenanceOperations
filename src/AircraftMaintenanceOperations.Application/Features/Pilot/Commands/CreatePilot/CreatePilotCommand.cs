namespace AircraftMaintenanceOperations.Application.Features.Pilot.Commands.CreatePilot;

public record CreatePilotCommand(
    string Rank,
    string LicenseNumber
    ) : ICommand<CreatePilotCommandResult>;

public record CreatePilotCommandResult(Guid Id);
