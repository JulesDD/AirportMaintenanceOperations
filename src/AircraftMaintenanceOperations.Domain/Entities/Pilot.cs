namespace AircraftMaintenanceOperations.Domain.Entities;

public class Pilot : User   
{
    public string? Rank { get; set; } = string.Empty;
    public string? LicenseNumber { get; set; } = string.Empty;  
}
