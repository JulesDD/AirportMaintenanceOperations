namespace AircraftMaintenanceOperations.Application.Features.Aircraft.Commands.CreateAircraft;

public record CreateAircraftCommand(
    string TailNumber,
    string Model,
    string Manufacturer,
    string SerialNumber,
    int YearOfManufacture,
    string CurrentLocation
    ) : ICommand<CreateAircraftCommandResult>;

public record CreateAircraftCommandResult(Guid AircraftId);
