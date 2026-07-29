namespace AircraftMaintenanceOperations.Application.Features.DTOs;

public record PilotDto
(
    string EmployeeNumber,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string Rank,
    string LicenseNumber
);