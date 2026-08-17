namespace AircraftMaintenanceOperations.Application.Features.DTOs;

public record AircraftSummaryDto
(
    Guid AircraftId,
    string TailNumber,
    string Manufacturer,
    int Year,
    string SerialNumber,
    string Model,
    double FlightHours,
    DateTime? LastMaintenanceDate,
    DateTime? NextMaintenanceDate
);
