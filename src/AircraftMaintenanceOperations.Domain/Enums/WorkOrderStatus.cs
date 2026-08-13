namespace AircraftMaintenanceOperations.Domain.Enums;

public enum WorkOrderStatus
{
    Open,
    Assigned,
    InProgress,
    WaitingForParts,
    Inspection,
    Completed,
    Archived
}
