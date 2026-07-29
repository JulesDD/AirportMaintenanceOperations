namespace AircraftMaintenanceOperations.Application.Features.Pilot.Commands.UpdatePilot;

public record UpdatePilotCommand(
    Guid Id,
    string? FirstName,
    string? LastName,
    string? Email,
    string? PhoneNumber,
    string? Rank,
    string? LicenseNumber) : ICommand<UpdatePilotResult>;
public record UpdatePilotResult(bool IsSuccess);
