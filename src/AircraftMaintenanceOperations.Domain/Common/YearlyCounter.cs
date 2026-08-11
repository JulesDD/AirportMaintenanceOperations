namespace AircraftMaintenanceOperations.Domain.Common;

public abstract class YearlyCounter
{
    public YearlyCounter()
    {
    }
    public YearlyCounter(int year)
    {
        if (year < 2026) throw new DomainException("Invalid year. Please specify a year of 2026 or later.");
        Year = year;
        CurrentNumber = 0;
    }

    public Guid Id { get; set; }
    public int Year { get; private set; }
    public int CurrentNumber { get; private set; }
    public byte[] RowVersion { get; set; } = default!;

    public int GetNextNumber()
    {
        CurrentNumber++;
        return CurrentNumber;
    }

    
}
