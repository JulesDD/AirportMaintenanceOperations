namespace AircraftMaintenanceOperations.Application.Features.Aircraft.DTOs;

public record AircraftDto
(
    string TailNumber,
    string Manufacturer,
    string Model,
    string SerialNumber,
    int YearOfManufacture
);
