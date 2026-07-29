namespace AircraftMaintenanceOperations.Application.Features.Aircraft.Commands.UpdateAircraft;

public record UpdateAircraftCommand(
    Guid Id,
    string? currentAirport,
    double flightHours,
    DateTime lastMaintenanceDate,
    DateTime nextMaintenanceDate) : ICommand<UpdateAircraftResult>;

public record UpdateAircraftResult(bool IsSuccess);