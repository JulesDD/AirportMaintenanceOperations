namespace AircraftMaintenanceOperations.Domain.Entities;

public class Technician : User
{
    public CertificationLevel CertificationLevel { get; private set; }
    public int YearsOfExperience { get; private set; }

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
            Status = EmploymentStatus.Active
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
        if (Status == EmploymentStatus.OnBreak) throw new InvalidOperationException("Technician is already on break.");
        Status = EmploymentStatus.OnBreak;
    }

    public void EndBreak()
    {
        if (Status != EmploymentStatus.OnBreak)
            throw new InvalidOperationException("Technician is not on break.");
        Status = EmploymentStatus.Active;
    }

    public void StartMedicalLeave()
    {
        if (Status == EmploymentStatus.MedicalLeave)
            throw new InvalidOperationException("Technician is already on medical leave.");
        Status = EmploymentStatus.MedicalLeave;
    }

    public void EndMedicalLeave()
    {
        if (Status != EmploymentStatus.MedicalLeave)
            throw new InvalidOperationException("Technician is not on medical leave.");
        Status = EmploymentStatus.Active;
    }

    public void StartVacation()
    {
        if (Status == EmploymentStatus.Vacation)
            throw new InvalidOperationException("Technician is already on vacation.");
        Status = EmploymentStatus.Vacation;
    }

    public void EndVacation()
    {
        if (Status != EmploymentStatus.Vacation)
            throw new InvalidOperationException("Technician is not on vacation.");
        Status = EmploymentStatus.Active;
    }

    public void Retire()
    {
        if (Status == EmploymentStatus.Retired)
            throw new InvalidOperationException("Technician is already retired.");
        Status = EmploymentStatus.Retired;
    }

    public void Suspend()
    {
        if (Status == EmploymentStatus.Suspended)
            throw new InvalidOperationException("Technician is already suspended.");
        Status = EmploymentStatus.Suspended;
    }

    public void Reinstate()
    {
        if (Status != EmploymentStatus.Suspended)
            throw new InvalidOperationException("Technician is not suspended.");
        Status = EmploymentStatus.Active;
    }

    public void Training()
    {
        if (Status == EmploymentStatus.Training)
            throw new InvalidOperationException("Technician is already in training.");
        Status = EmploymentStatus.Training;
    }

    public void Archive()
    {
        if (Status == EmploymentStatus.Archived)
            throw new InvalidOperationException("Technician is already archived.");
        Status = EmploymentStatus.Archived;
    }
}
