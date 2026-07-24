namespace AircraftMaintenanceOperations.Application.Features.Pilot.Queries.ArchivePilot;

public record ArchivePilotRequest(Guid PilotId) : ICommand<ArchivePilotRequestResult>;
public record ArchivePilotRequestResult(bool IsSuccess);
