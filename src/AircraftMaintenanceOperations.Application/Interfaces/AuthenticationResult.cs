namespace AircraftMaintenanceOperations.Application.Interfaces;

public record AuthenticationResult
(
    Guid UserId,
    string UserName,
    IEnumerable<string> Roles
);
