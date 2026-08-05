namespace AircraftMaintenanceOperations.Application.Abstractions.Services;

internal interface INumberGenerator
{
    Task<string> GenerateWorkOrderNumberAsync();
    Task<string> GenerateMaintenanceRequestNumberAsync();
}
