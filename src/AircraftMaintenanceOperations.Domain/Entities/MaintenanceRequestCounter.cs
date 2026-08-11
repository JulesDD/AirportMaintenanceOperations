namespace AircraftMaintenanceOperations.Domain.Entities;

public sealed class MaintenanceRequestCounter : YearlyCounter
{
    private MaintenanceRequestCounter() { }

    public MaintenanceRequestCounter(int year)
        : base(year)
    {
    }
}
