namespace AircraftMaintenanceOperations.Application.Features.DTOs;

public record WorkOrderDto
(
    Guid Id,
    string workOrderNumber,
    Guid MaintenanceRequestId,
    Guid AircraftId,
    Guid AssignedTechnicianId,
    MaintenancePriority WorkOrderPriority,
    WorkOrderStatus WorkOrderStatus,
    DateTime EstimatedCompletionDate
);