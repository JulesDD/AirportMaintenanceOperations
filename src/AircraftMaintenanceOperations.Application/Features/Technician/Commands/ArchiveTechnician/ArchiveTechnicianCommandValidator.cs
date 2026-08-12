namespace AircraftMaintenanceOperations.Application.Features.Technician.Commands.ArchiveTechnician;

public class ArchiveTechnicianCommandValidator : AbstractValidator<ArchiveTechnicianCommand>
{
    public ArchiveTechnicianCommandValidator()
    {
        RuleFor(x => x.TechnicianId).NotEmpty().WithMessage("Technician ID is required");
    }
}
