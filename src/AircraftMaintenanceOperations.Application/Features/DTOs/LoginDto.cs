namespace AircraftMaintenanceOperations.Application.Features.DTOs;

public record LoginDto
(
    string AccessToken,
    DateTime ExpiresAt,
    string UserId,
    string UserName,
    string Role
);
