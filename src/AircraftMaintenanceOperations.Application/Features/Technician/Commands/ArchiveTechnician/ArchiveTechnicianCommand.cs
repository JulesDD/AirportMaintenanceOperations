namespace AircraftMaintenanceOperations.Application.Features.Technician.Commands.ArchiveTechnician;

public record ArchiveTechnicianCommand(Guid TechnicianId) : ICommand<ArchiveTechnicianCommandResult>;
public record ArchiveTechnicianCommandResult(bool IsSuccess);
