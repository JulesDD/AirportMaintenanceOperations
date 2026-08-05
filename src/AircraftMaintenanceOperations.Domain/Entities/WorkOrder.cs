namespace AircraftMaintenanceOperations.Domain.Entities;

public class WorkOrder : BaseEntity
{
    public string WorkOrderNumber { get; set; } = string.Empty;
    public string MaintenanceNumber { get; set; } = string.Empty;
    public Guid MaintenanceRequestId { get; set; }
    public MaintenanceRequest? MaintenanceRequest { get; set; } = null!;
    public Guid AircraftId { get; set; }
    public Guid AssignedTechnicianId { get; set; }
    public Technician? Technician { get; set; } = null!;
    public MaintenancePriority WorkOrderPriority { get; set; }
    public WorkOrderStatus WorkOrderStatus { get; set; }
    public DateTime EstimatedCompletionDate { get; set; }
    public DateTime? ActualCompletionDate { get; set; }
    public decimal EstimatedCompletionPercent { get; set; }
    public decimal ActualCompletionPercent { get; set; }
    public decimal LaborHours { get; set; }
    public string? LaborNotes { get; set; }
    public ICollection<InventoryUsage> InventoryUsages { get; set; }
    = new List<InventoryUsage>();

    public void AssignTechnician(Guid technicianId)
    {
        AssignedTechnicianId = technicianId;
    }

    public void MarkAsInProgress()
    {
        WorkOrderStatus = WorkOrderStatus.InProgress;
    }

    public void MarkAsCompleted(string laborNotes, decimal laborHours)
    {
        WorkOrderStatus = WorkOrderStatus.Completed;
        ActualCompletionDate = DateTime.UtcNow;
        ActualCompletionPercent = 100;
        LaborNotes = laborNotes;
        LaborHours = laborHours;
    }

}