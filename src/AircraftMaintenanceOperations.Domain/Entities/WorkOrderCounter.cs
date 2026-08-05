namespace AircraftMaintenanceOperations.Domain.Entities;

public class WorkOrderCounter
{
    public Guid Id { get; set; }
    public int Year { get; set; }
    public int CurrentNumber { get; set; }
    public byte[] RowVersion { get; set; } = default!;

    private WorkOrderCounter()
    {
    }
    public WorkOrderCounter(int year)
    {
        Year = year;
        CurrentNumber = 0;
    }

    public int GetNextNumber()
    {
        CurrentNumber++;
        return CurrentNumber;
    }
}
