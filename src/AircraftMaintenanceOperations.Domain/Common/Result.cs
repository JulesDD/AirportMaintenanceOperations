namespace AircraftMaintenanceOperations.Domain.Common;

public record DomainResult(bool IsSuccess, string? ErrorMessage = null);