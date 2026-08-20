namespace AircraftMaintenanceOperations.Application.Features.DTOs;

public record LoginDto
(
    string AccessToken,
    DateTime ExpiresAt,
    Guid UserId,
    string UserName,
    IEnumerable<string> Roles
);
