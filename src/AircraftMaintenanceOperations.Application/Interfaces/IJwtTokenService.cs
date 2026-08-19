namespace AircraftMaintenanceOperations.Application.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(Guid userId, string username, IEnumerable<string> roles);
}
