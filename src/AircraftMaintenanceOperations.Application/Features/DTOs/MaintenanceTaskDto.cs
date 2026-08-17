namespace AircraftMaintenanceOperations.Application.Features.DTOs;

public record MaintenanceTaskDto
(
    MaintenanceTaskType Tag,
    string ReferenceNumber,
    string Title,
    MaintenancePriority Priority,
    string Status,
    DateTime DueDate,
    Guid? TechnicianId,
    AircraftSummaryDto? AircraftSummary
);
