namespace AircraftMaintenanceOperations.Domain.Entities;

public class Technician : User
{
    public CertificationLevel CertificationLevel { get; private set; }
    public int YearsOfExperience { get; private set; }
    public TechnicianStatus Status { get; private set; }

    public static Technician Create(
        string employeeNumber,
        string firstName,
        string lastName,
        string email,
        string phoneNumber,
        CertificationLevel certificationLevel,
        int yearsOfExperience)
    {
        return new Technician
        {
            EmployeeNumber = employeeNumber,
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            PhoneNumber = phoneNumber,
            Role = Role.Technician,
            CertificationLevel = certificationLevel,
            YearsOfExperience = yearsOfExperience,
            Status = TechnicianStatus.Active
        };
    }

    public void Update(
        string firstName,
        string lastName,
        string email,
        string phoneNumber,
        CertificationLevel certificationLevel,
        int yearsOfExperience)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        CertificationLevel = certificationLevel;
        YearsOfExperience = yearsOfExperience;
    }

    public void StartBreak()
    {
        if (Status == TechnicianStatus.OnBreak) throw new InvalidOperationException("Technician is already on break.");
        Status = TechnicianStatus.OnBreak;
    }

    public void EndBreak()
    {
        if (Status != TechnicianStatus.OnBreak)
            throw new InvalidOperationException("Technician is not on break.");
        Status = TechnicianStatus.Active;
    }

    public void StartMedicalLeave()
    {
        if (Status == TechnicianStatus.MedicalLeave)
            throw new InvalidOperationException("Technician is already on medical leave.");
        Status = TechnicianStatus.MedicalLeave;
    }

    public void EndMedicalLeave()
    {
        if (Status != TechnicianStatus.MedicalLeave)
            throw new InvalidOperationException("Technician is not on medical leave.");
        Status = TechnicianStatus.Active;
    }

    public void StartVacation()
    {
        if (Status == TechnicianStatus.Vacation)
            throw new InvalidOperationException("Technician is already on vacation.");
        Status = TechnicianStatus.Vacation;
    }

    public void EndVacation()
    {
        if (Status != TechnicianStatus.Vacation)
            throw new InvalidOperationException("Technician is not on vacation.");
        Status = TechnicianStatus.Active;
    }

    public void Retire()
    {
        if (Status == TechnicianStatus.Retired)
            throw new InvalidOperationException("Technician is already retired.");
        Status = TechnicianStatus.Retired;
    }

    public void Suspend()
    {
        if (Status == TechnicianStatus.Suspended)
            throw new InvalidOperationException("Technician is already suspended.");
        Status = TechnicianStatus.Suspended;
    }

    public void Reinstate()
    {
        if (Status != TechnicianStatus.Suspended)
            throw new InvalidOperationException("Technician is not suspended.");
        Status = TechnicianStatus.Active;
    }

    public void Training()
    {
        if (Status == TechnicianStatus.Training)
            throw new InvalidOperationException("Technician is already in training.");
        Status = TechnicianStatus.Training;
    }

    public void Archive()
    {
        if (Status == TechnicianStatus.Archived)
            throw new InvalidOperationException("Technician is already archived.");
        Status = TechnicianStatus.Archived;
    }
}
