namespace AircraftMaintenanceOperations.Application.Features.DTOs;

public record TechnicianDto
(
    string EmployeeNumber,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    TechnicianStatus Status,
    CertificationLevel CertificationLevel,
    int YearsOfExperience
);
