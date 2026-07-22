namespace AircraftMaintenanceOperations.Domain.Entities;

public class Aircraft : BaseEntity
{
    public string TailNumber { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
    public int Year { get; set; }
    public string SerialNumber { get; set; } = string.Empty;
    public string CurrentAirport { get; set; } = string.Empty;
    public double FlightHours { get; set; }
    public string Model { get; set; } = string.Empty;
    public AircraftStatus Status { get; set; }
    public DateTime LastMaintenanceDate { get; set; }
    public DateTime NextMaintenanceDate { get; set; }
    public Guid? CurrentPilotId { get; set; }

    public Pilot? CurrentPilot { get; set; } = null!;
    public IEnumerable<MaintenanceRequest> MaintenanceRequests { get; set; } = new List<MaintenanceRequest>();
    //public IEnumerable<MaintenanceHistory> MaintenanceHistories { get; set; } = new List<MaintenanceHistory>();

    public void Ground()
    {
        Status = AircraftStatus.Grounded;
    }

    public void UpdateMaintenanceDates(DateTime lastMaintenanceDate, DateTime nextMaintenanceDate)
    {
        LastMaintenanceDate = lastMaintenanceDate;
        NextMaintenanceDate = nextMaintenanceDate;
    }

    public void UpdateCurrentAirport(string airportCode)
    {
        CurrentAirport = airportCode;
    }

    public void ReturnToService()
    {
        Status = AircraftStatus.Operational;
    }

    public void Archive()
    {
        Status = AircraftStatus.Archived;
    }

    public DomainResult AssignPilot(Pilot pilot)
    {
        if (CurrentPilot != null) return new(false, "This aircraft already has a pilot assigned. Please unassign the current pilot first.");
        if (Status == AircraftStatus.Archived) return new(false, "Cannot assign a pilot to an archived aircraft.");
        if (Status == AircraftStatus.OutOfService) return new(false, "Cannot assign a pilot to an out-of-service aircraft. The aircraft must be returned to service first.");
        if (pilot.Id == Guid.Empty) return new(false, "Pilot must have a valid ID.");

        CurrentPilot = pilot;
        CurrentPilotId = pilot.Id;

        return new(true);
    }

    public void UnassignPilot()
    {
        CurrentPilot = null;
        CurrentPilotId = null;
    }

    public void UpdateFlightHours(double flightHours)
    {
        if (flightHours < 0)
        {
            throw new ArgumentException("Flight hours cannot be negative.");
        }
        FlightHours = flightHours;
    }

    public static Aircraft Create(
        string tailNumber,
        string manufacturer,
        string model,
        string serialNumber,
        int year,
        string currentAirport)
    {
        return new Aircraft
        {
            TailNumber = tailNumber,
            Manufacturer = manufacturer,
            Model = model,
            SerialNumber = serialNumber,
            Year = year,
            CurrentAirport = currentAirport,
            Status = AircraftStatus.Grounded,
            FlightHours = 0
        };
    }
}
