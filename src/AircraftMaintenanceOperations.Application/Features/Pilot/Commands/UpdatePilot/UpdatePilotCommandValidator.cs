namespace AircraftMaintenanceOperations.Application.Features.Pilot.Commands.UpdatePilot;

public class UpdatePilotCommandValidator : AbstractValidator<UpdatePilotCommand>
{
    public UpdatePilotCommandValidator()
    {
        RuleFor(x => x.PilotId).NotEmpty().WithMessage("Pilot ID is required");
    }
}
