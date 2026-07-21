namespace AircraftMaintenanceOperations.Application.Features.Aircraft.Commands.ArchiveAircraft;

public record ArchiveAircraftCommand(Guid AircraftId) : ICommand<ArchiveAircraftResult>;
public record ArchiveAircraftResult(bool IsSuccess);
