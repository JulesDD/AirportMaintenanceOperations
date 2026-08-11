namespace AircraftMaintenanceOperations.Domain.Entities;

public sealed class WorkOrderCounter : YearlyCounter
{
    private WorkOrderCounter() { }

    public WorkOrderCounter(int year)
        : base(year)
    {
    }
}
