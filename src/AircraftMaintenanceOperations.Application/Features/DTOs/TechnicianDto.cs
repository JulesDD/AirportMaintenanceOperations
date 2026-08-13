namespace AircraftMaintenanceOperations.Application.Features.DTOs;

public record TechnicianDto
(
    string EmployeeNumber,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    EmploymentStatus Status,
    CertificationLevel CertificationLevel,
    int YearsOfExperience
);
