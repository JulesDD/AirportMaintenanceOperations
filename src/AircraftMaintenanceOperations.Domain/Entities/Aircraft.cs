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

    public void AssignPilot(Guid pilotId)
    {
        CurrentPilotId = pilotId;
    }

    public void Archive()
    {
        Status = AircraftStatus.Archived;
    }

    public void AssignPilot(Pilot pilot)
    {
        CurrentPilot = pilot;
        CurrentPilotId = pilot.Id;
    }

    public void UnassignPilot()
    {
        CurrentPilot = null;
        CurrentPilotId = null;
    }

    public void updateFlightHours(double flightHours)
    {
        if (flightHours < 0)
        {
            throw new ArgumentException("Flight hours cannot be negative.");
        }
        FlightHours = flightHours;
    }
}
