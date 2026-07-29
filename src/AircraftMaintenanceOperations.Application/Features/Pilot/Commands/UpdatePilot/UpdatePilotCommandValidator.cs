namespace AircraftMaintenanceOperations.Application.Features.Pilot.Commands.UpdatePilot;

public class UpdatePilotCommandValidator : AbstractValidator<UpdatePilotCommand>
{
    public UpdatePilotCommandValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress()
            .When(x => !string.IsNullOrWhiteSpace(x.Email));

        RuleFor(x => x.FirstName)
            .MaximumLength(50)
            .When(x => x.FirstName is not null);

        RuleFor(x => x.LastName)
            .MaximumLength(50)
            .When(x => x.LastName is not null);

        RuleFor(x => x.PhoneNumber)
            .MaximumLength(20)
            .When(x => x.PhoneNumber is not null);

        RuleFor(x => x.Rank)
            .MaximumLength(50)
            .When(x => x.Rank is not null);

        RuleFor(x => x.LicenseNumber)
            .MaximumLength(20)
            .When(x => x.LicenseNumber is not null);
    }
}
