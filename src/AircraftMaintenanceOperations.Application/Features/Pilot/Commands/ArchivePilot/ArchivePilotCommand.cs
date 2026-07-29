namespace AircraftMaintenanceOperations.Application.Features.Pilot.Queries.ArchivePilot;

public record ArchivePilotCommand(Guid PilotId, bool IsArchived) : ICommand<ArchivePilotResult>;
public record ArchivePilotResult(bool IsSuccess);
