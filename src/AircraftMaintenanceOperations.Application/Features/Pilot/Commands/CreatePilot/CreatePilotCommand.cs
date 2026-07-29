namespace AircraftMaintenanceOperations.Application.Features.Pilot.Commands.CreatePilot;

public record CreatePilotCommand(
    string EmployeeNumber,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string Rank,
    string LicenseNumber
    ) : ICommand<CreatePilotCommandResult>;

public record CreatePilotCommandResult(Guid Id);
