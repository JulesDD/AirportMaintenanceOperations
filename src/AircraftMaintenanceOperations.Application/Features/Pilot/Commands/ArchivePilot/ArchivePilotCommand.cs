namespace AircraftMaintenanceOperations.Application.Features.Pilot.Queries.ArchivePilot;

public record ArchivePilotCommand(Guid PilotId) : ICommand<ArchivePilotCommandResult>;
public record ArchivePilotCommandResult(bool IsSuccess);
