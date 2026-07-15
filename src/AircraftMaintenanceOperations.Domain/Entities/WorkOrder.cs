namespace AircraftMaintenanceOperations.Domain.Entities;

public class WorkOrder : BaseEntity
{
    public Guid MaintenanceRequestId { get; set; }
    public MaintenanceRequest? MaintenanceRequest { get; set; } = null!;
    public Guid TechnicianId { get; set; }
    public Technician? Technician { get; set; } = null!;
    public WorkOrderStatus Status { get; set; }
    public DateTime EstimatedCompletionDate { get; set; }
    public DateTime? ActualCompletionDate { get; set; }
    public decimal EstimatedCompletionPercent { get; set; }
    public decimal ActualCompletionPercent { get; set; }
    public decimal LaborHours { get; set; }
    public string? LaborNotes { get; set; }

    public void AssignTechnician(Guid technicianId)
    {
        TechnicianId = technicianId;
    }

    public void MarkAsInProgress()
    {
        Status = WorkOrderStatus.InProgress;
    }

    public void MarkAsCompleted(string laborNotes, decimal laborHours)
    {
        Status = WorkOrderStatus.Completed;
        ActualCompletionDate = DateTime.UtcNow;
        ActualCompletionPercent = 100;
        LaborNotes = laborNotes;
        LaborHours = laborHours;
    }

}