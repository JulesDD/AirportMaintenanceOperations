namespace AircraftMaintenanceOperations.Application.Features.AssignPilot.Command;

public class AssignPilotCommandValidator : AbstractValidator<AssignPilotCommand>
{
    public AssignPilotCommandValidator()
    {
        RuleFor(x => x.PilotId).NotEmpty().WithMessage("Pilot should not be null");
        RuleFor(x => x.AircraftId).NotEmpty().WithMessage("AircraftId should not be null");
    }
}
