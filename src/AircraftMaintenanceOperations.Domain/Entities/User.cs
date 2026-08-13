namespace AircraftMaintenanceOperations.Domain.Entities;

public class User : BaseEntity
{
    public string? EmployeeNumber { get; protected set; } = string.Empty;
    public string? FirstName { get; protected set; } = string.Empty;
    public string? LastName { get; protected set; } = string.Empty;
    public string? Email { get; protected set; } = string.Empty;
    public string? PhoneNumber { get; protected set; } = string.Empty;
    public Role Role { get; protected set; }
    public EmploymentStatus Status { get; protected set; }
}