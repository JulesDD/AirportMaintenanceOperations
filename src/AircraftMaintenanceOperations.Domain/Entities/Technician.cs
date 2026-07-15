namespace AircraftMaintenanceOperations.Domain.Entities;

public class Technician : User
{
    public int CertificationLevel { get; set; }
    public int YearsOfExperience { get; set; }
}
