namespace AircraftMaintenanceOperations.Application.Features.Technician.Commands.UpdateTechnician;

public record UpdateTechnicianCommand(
    Guid TechnicianId, 
    string FirstName,
    string LastName,
    string PhoneNumber,
    string Email,
    CertificationLevel CertificationLevel,
    int YearsOfExperience) : ICommand<UpdateTechnicianCommandResult>;
public record UpdateTechnicianCommandResult(bool IsSuccess);
