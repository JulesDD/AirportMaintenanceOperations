namespace AircraftMaintenanceOperations.Domain.Entities;

public class Pilot : User   
{
    public string? Rank { get; set; } = string.Empty;
    public string? LicenseNumber { get; set; } = string.Empty;
    public PilotStatus Status { get; set; }

    public static Pilot Create(
        string rank,
        string liscenseNumber)
    {
        return new Pilot
        {
            Rank = rank,
            LicenseNumber = liscenseNumber,
            Status = PilotStatus.Active
        };
    }

    public void Update(
    string rank,
    string licenseNumber)
    {
        Rank = rank;
        LicenseNumber = licenseNumber;
    }

    public void StartBreak()
    {
        Status = PilotStatus.OnBreak;
    }

    public void EndBreak()
    {
        Status = PilotStatus.Active;
    }

    public void BeginMedicalLeave()
    {
        Status = PilotStatus.MedicalLeave;
    }

    public void ReturnToDuty()
    {
        Status = PilotStatus.Active;
    }

    public void StartTraining()
    {
        Status = PilotStatus.Training;
    }

    public void Suspended()
    {
        Status = PilotStatus.Suspended;
    }

    public void Retired()
    {
        Status = PilotStatus.Retired;
    }

    public void Archive()
    {
        Status = PilotStatus.Archived;
    }
}
