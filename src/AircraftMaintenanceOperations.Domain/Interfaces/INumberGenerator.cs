namespace AircraftMaintenanceOperations.Domain.Interfaces;

public interface INumberGenerator
{
    Task<string> GenerateWorkOrderNumberAsync();
    Task<string> GenerateMaintenanceRequestNumberAsync();
}
