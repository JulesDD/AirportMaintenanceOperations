namespace AircraftMaintenanceOperations.Application.Features.Pilot.Commands.CreatePilot;

public class CreatePilotCommandValidator : AbstractValidator<CreatePilotCommand>
{

    public CreatePilotCommandValidator()
    {
        RuleFor(x => x.Rank).NotEmpty().WithMessage("Pilot Rank is required");
        RuleFor(x => x.LicenseNumber).NotEmpty().WithMessage("Please provide a license Number for the Pilot");
    }
}
