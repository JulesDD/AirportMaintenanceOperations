namespace AircraftMaintenanceOperations.Application.Features.Technician.Commands.CreateTechnician;

public record CreateTechnicianCommand(
    string EmployeeNumber,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    CertificationLevel CertificationLevel,
    int YearsOfExperience
    ) : ICommand<CreateTechnicianCommandResult>;
public record CreateTechnicianCommandResult(Guid Id);
