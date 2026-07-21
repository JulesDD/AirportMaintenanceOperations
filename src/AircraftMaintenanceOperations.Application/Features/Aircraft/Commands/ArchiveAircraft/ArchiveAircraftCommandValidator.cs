namespace AircraftMaintenanceOperations.Application.Features.Aircraft.Commands.ArchiveAircraft;

public class ArchiveAircraftCommandValidator : AbstractValidator<ArchiveAircraftCommand>
{
    public ArchiveAircraftCommandValidator()
    {
        RuleFor(x => x.AircraftId).NotEmpty().WithMessage("Aircraft ID is required.");
    }
}
