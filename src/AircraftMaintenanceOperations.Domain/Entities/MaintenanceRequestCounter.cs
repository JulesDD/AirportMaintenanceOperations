namespace AircraftMaintenanceOperations.Domain.Entities;

public class MaintenanceRequestCounter
{
    public Guid Id { get; set; }
    public int Year { get; set; }
    public int CurrentNumber { get; set; }
    public byte[] RowVersion { get; set; } = default!;

    private MaintenanceRequestCounter()
    {
    }

    public MaintenanceRequestCounter(int year)
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
