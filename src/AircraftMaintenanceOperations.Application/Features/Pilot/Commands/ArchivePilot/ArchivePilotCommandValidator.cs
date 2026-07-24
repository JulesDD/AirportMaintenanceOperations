namespace AircraftMaintenanceOperations.Application.Features.Pilot.Queries.ArchivePilot;

public class ArchivePilotCommandValidator : AbstractValidator<ArchivePilotCommand>
{
    public ArchivePilotCommandValidator()
    {
        RuleFor(x => x.PilotId).NotEmpty().WithMessage("Pilot ID is required");
    }
}
