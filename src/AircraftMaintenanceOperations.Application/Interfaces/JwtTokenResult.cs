namespace AircraftMaintenanceOperations.Application.Interfaces;

public record JwtTokenResult
(
    string AccessToken,
    DateTime ExpiresAt
);
