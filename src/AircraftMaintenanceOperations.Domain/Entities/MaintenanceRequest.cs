namespace AircraftMaintenanceOperations.Domain.Entities;

public class MaintenanceRequest : BaseEntity
{
    public string RequestNumber { get; private set; }
    public Guid AircraftId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; set; } = string.Empty;
    public MaintenancePriority MaintenancePriority { get; set; }
    public MaintenanceRequestStatus MaintenanceRequestStatus { get; private set; }
    public Aircraft Aircraft { get; private set; }
    public string RequestedBy { get; set; }
    public DateTime RequestedDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime ClosedDate { get; set; }

    public static MaintenanceRequest Create(
        string requestNumber,
        string title,
        Guid aircraftId,
        string description,
        string requestedBy,
        DateTime dueDate)
    {
        if (dueDate < DateTime.UtcNow) throw new InvalidOperationException("Due date cannot be in the past.");
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
            DueDate = dueDate
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
        if (requestNumber != null) requestNumber = requestNumber.Trim();
        if (title is not null) Title = title;
        if (description is not null) Description = description;
        if (!(requestedDate < DateTime.UtcNow)) RequestedDate = requestedDate; else RequestedDate = DateTime.UtcNow;
        if (dueDate < DateTime.UtcNow) DueDate = DateTime.UtcNow;
        if (!(closedDate < DateTime.UtcNow)) ClosedDate = closedDate;
    }

    public void MediumPriority()
    {
        MaintenancePriority = MaintenancePriority.Medium;
    }

    public void HighPriority()
    {
        MaintenancePriority = MaintenancePriority.High;
    }

    public void CriticalPriority()
    {
        MaintenancePriority = MaintenancePriority.Critical;
    }

    public void InProgressRequestStatus()
    {
        if (MaintenanceRequestStatus == MaintenanceRequestStatus.Closed) throw new InvalidOperationException("Cannot move closed request to in progress.");
        MaintenanceRequestStatus = MaintenanceRequestStatus.InProgress;
    }

    public void AwaitingParts()
    {
        MaintenanceRequestStatus = MaintenanceRequestStatus.AwaitingParts;
    }

    public void Complete()
    {
        MaintenanceRequestStatus = MaintenanceRequestStatus.Completed;
    }

    public void Closed()
    {
        MaintenanceRequestStatus = MaintenanceRequestStatus.Closed;
        ClosedDate = DateTime.UtcNow;
    }

    public void Archive()
    {
        MaintenanceRequestStatus = MaintenanceRequestStatus.Archived;
    }
}
