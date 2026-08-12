namespace AircraftMaintenanceOperations.Domain.Entities;

public class WorkOrder : BaseEntity
{
    public string WorkOrderNumber { get; private set; } = string.Empty;
    public Guid MaintenanceRequestId { get; private set; }
    public MaintenanceRequest? MaintenanceRequest { get; private set; } = null!;
    public string? Title { get; private set; }
    public string? Description { get; private set; }    
    public Guid AircraftId { get; private set; }
    public Guid AssignedTechnicianId { get; private set; }
    public MaintenancePriority WorkOrderPriority { get; private set; }
    public WorkOrderStatus WorkOrderStatus { get; private set; }
    public DateTime EstimatedCompletionDate { get; private set; }
    public DateTime? ActualCompletionDate { get; private set; }
    public decimal LaborHours { get; private set; }
    public string? LaborNotes { get; private set; }
    public ICollection<InventoryUsage> InventoryUsages { get; private set; }
    = new List<InventoryUsage>();

    public static WorkOrder Create(
        string workOrderNumber,
        Guid maintenanceRequestId,
        Guid aircraftId,
        Guid assignedTechnicianId,
        MaintenancePriority workOrderPriority,
        DateTime estimatedCompletionDate)
    {
        return new WorkOrder
        {
            WorkOrderNumber = workOrderNumber,
            MaintenanceRequestId = maintenanceRequestId,
            AircraftId = aircraftId,
            AssignedTechnicianId = assignedTechnicianId,
            WorkOrderPriority = workOrderPriority,
            WorkOrderStatus = WorkOrderStatus.Open,
            EstimatedCompletionDate = estimatedCompletionDate
        };
    }

    public void UpdateDetails(
    string title,
    string description,
    MaintenancePriority priority,
    DateTime estimatedCompletionDate)
    {
        if (WorkOrderStatus == WorkOrderStatus.Archived) throw new InvalidOperationException("Archived work orders cannot be updated.");

        Title = title;
        Description = description;
        WorkOrderPriority = priority;
        EstimatedCompletionDate = estimatedCompletionDate;
    }


    public void MediumPriority()
    {
        WorkOrderPriority = MaintenancePriority.Medium;
    }

    public void HighPriority()
    {
        WorkOrderPriority = MaintenancePriority.High;
    }

    public void CriticalPriority()
    {
        WorkOrderPriority = MaintenancePriority.Critical;
    }

    public DomainResult AssignTechnician(Technician technician)
    {
        if(WorkOrderStatus == WorkOrderStatus.Archived) return new(false, "Archived work orders cannot be assigned to a technician.");
        if(technician is null) return new(false, "Invalid technician."); 
        if(technician.Status != TechnicianStatus.Active) return new(false, "Only active technicians can be assigned to work orders.");
        if(technician.Status == TechnicianStatus.Active && WorkOrderStatus == WorkOrderStatus.Assigned) return new(false, "Work order is already assigned to a technician."); 

        AssignedTechnicianId = technician.Id;
        return new(true);
    }

    public void OpenWorkOrder(string laborNotes)
    {
        WorkOrderStatus = WorkOrderStatus.Open;
        LaborNotes = laborNotes;
    }

    public void AssignWorkOrder(string laborNotes)
    {
        WorkOrderStatus = WorkOrderStatus.Assigned;
        LaborNotes = laborNotes;
    }

    public void InProgress(string laborNotes)
    {
        WorkOrderStatus = WorkOrderStatus.InProgress;
        LaborNotes = laborNotes;
    }

    public void WaitingForParts(string laborNotes)
    {
        WorkOrderStatus = WorkOrderStatus.WaitingForParts;
        LaborNotes = laborNotes;
    }

    public void Inspection(string laborNotes)
    {
        WorkOrderStatus = WorkOrderStatus.Inspection;
        LaborNotes = laborNotes;
    }

    public void Completed(string laborNotes, decimal laborHours)
    {
        WorkOrderStatus = WorkOrderStatus.Completed;
        ActualCompletionDate = DateTime.UtcNow;
        LaborNotes = laborNotes;
        LaborHours = laborHours;
    }

    public void ArchiveWorkOrder()
    {
        if (WorkOrderStatus != WorkOrderStatus.Completed) throw new DomainException("Only completed work orders can be archived.");

        WorkOrderStatus = WorkOrderStatus.Archived;
    }

}