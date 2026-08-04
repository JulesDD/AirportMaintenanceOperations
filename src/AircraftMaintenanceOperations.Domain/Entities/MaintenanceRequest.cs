namespace AircraftMaintenanceOperations.Domain.Entities;

public class MaintenanceRequest : BaseEntity
{
    public string RequestNumber { get; set; }
    public Guid AircraftId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; } = string.Empty;
    public MaintenancePriority MaintenancePriority { get; set; }
    public MaintenanceRequestStatus MaintenanceRequestStatus { get; set; }
    public Aircraft Aircraft { get; set; }
    public string RequestedBy { get; set; }
    public DateTime RequestedDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastModified { get; set; }
    public DateTime ClosedDate { get; set; }

    public static MaintenanceRequest Create(
        string requestNumber,
        string title,
        Guid aircraftId,
        string description,
        string requestedBy,
        DateTime dueDate)
    {
        return new MaintenanceRequest
        {
            RequestNumber = requestNumber,
            Title = title,
            Description = description,
            AircraftId = aircraftId,
            MaintenancePriority = MaintenancePriority.Low,
            MaintenanceRequestStatus = MaintenanceRequestStatus.Open,
            RequestedBy = requestedBy,
            RequestedDate = DateTime.UtcNow,
            DueDate = dueDate,
            CreatedDate = DateTime.UtcNow,
            LastModified = DateTime.UtcNow
        };
    }

    public void Update(
        string requestNumber,
        string title,
        Guid aircraftId,
        string description,
        DateTime requestedDate,
        DateTime dueDate,
        DateTime closedDate
        )
    {
        if ( requestNumber == null ) return; requestNumber = requestNumber.Trim();
        if (title is not null) Title = title;
        if (aircraftId != Aircraft.Id) return;
        if (description is not null) Description = description;
        if (!(requestedDate < DateTime.UtcNow)) RequestedDate = requestedDate; else RequestedDate = DateTime.UtcNow;
        if (dueDate < DateTime.UtcNow) DueDate = DateTime.UtcNow;
        if (!(closedDate < DateTime.UtcNow)) ClosedDate = closedDate;
        LastModified = DateTime.UtcNow;
    }

    public void MediumPriorty()
    {
        MaintenancePriority = MaintenancePriority.Medium;
        LastModified = DateTime.UtcNow;
    }

    public void HighPriorty()
    {
        MaintenancePriority = MaintenancePriority.High;
        LastModified = DateTime.UtcNow;
    }

    public void CriticalPriorty()
    {
        MaintenancePriority = MaintenancePriority.Critical;
        LastModified = DateTime.UtcNow;
    }

    public void InProgressRequestStatus()
    {
        MaintenanceRequestStatus = MaintenanceRequestStatus.InProgress;
    }

    public void AwaitingParts()
    {
        MaintenanceRequestStatus = MaintenanceRequestStatus.AwaitingParts;
        LastModified = DateTime.UtcNow;
    }

    public void Complete()
    {
        MaintenanceRequestStatus = MaintenanceRequestStatus.Completed;
        LastModified = DateTime.UtcNow;
    }

    public void Closed()
    {
        MaintenanceRequestStatus = MaintenanceRequestStatus.Closed;
        ClosedDate = DateTime.UtcNow;
        LastModified = DateTime.UtcNow;
    }

    public void Cancelled()
    {
        MaintenanceRequestStatus = MaintenanceRequestStatus.Cancelled;
        LastModified = DateTime.UtcNow;
    }
}
