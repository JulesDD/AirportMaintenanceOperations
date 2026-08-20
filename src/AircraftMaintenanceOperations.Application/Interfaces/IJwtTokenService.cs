namespace AircraftMaintenanceOperations.Application.Interfaces;

public interface IJwtTokenService
{
    JwtTokenResult GenerateToken(Guid userId, string username, IEnumerable<string> roles);
}
