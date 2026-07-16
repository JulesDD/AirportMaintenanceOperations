namespace AircraftMaintenanceOperations.Domain.Entities;

public class MaintenanceRequest : BaseEntity
{
    public Guid AircraftId { get; set; }
    public Guid ReportedByUserId { get; set; }
    public string Description { get; set; } = string.Empty;
    public MaintenancePriority MaintenancePriority { get; set; }
    public MaintenanceRequestStatus MaintenanceRequestStatus { get; set; }
    public DateTime DateReported { get; set; }
}
