namespace AircraftMaintenanceOperations.Domain.Entities;

public class User : BaseEntity
{
    public string? EmployeeNumber { get; set; } = string.Empty;
    public string? FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; } = string.Empty;
    public Role Role { get; set; }
}