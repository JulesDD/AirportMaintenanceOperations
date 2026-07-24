namespace AircraftMaintenanceOperations.Application.Features.Pilot.Queries.ArchivePilot;

public class ArchivePilotRequestValidator : AbstractValidator<ArchivePilotRequest>
{
    public ArchivePilotRequestValidator()
    {
        RuleFor(x => x.PilotId).NotEmpty().WithMessage("Pilot ID is required");
    }
}
