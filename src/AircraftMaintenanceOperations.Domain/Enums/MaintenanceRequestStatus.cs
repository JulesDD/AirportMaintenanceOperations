namespace AircraftMaintenanceOperations.Domain.Enums;

public enum MaintenanceRequestStatus
{
    Open,
    InProgress,
    AwaitingParts,
    Completed,
    Closed,
    Cancelled
}
