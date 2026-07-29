namespace AircraftMaintenanceOperations.Application.Features.Pilot.Commands.CreatePilot;

public class CreatePilotCommandValidator : AbstractValidator<CreatePilotCommand>
{

    public CreatePilotCommandValidator()
    {
        RuleFor(x => x.Rank).NotEmpty().WithMessage("Pilot Rank is required");
        RuleFor(x => x.LicenseNumber).NotEmpty().WithMessage("Please provide a license Number for the Pilot");
        //RuleFor(x => x.LicenseNumber).MustAsync(BeUniqueLicenseNumber).WithMessage("License Number must be unique. No duplicates");
    }

    //private async Task<bool> BeUniqueLicenseNumber(string LicenseNumber, CancellationToken cancellationToken)
    //{
    //    return !await _dbContext.Pilots.AnyAsync(p => p.LicenseNumber == LicenseNumber, cancellationToken);
    //}
}
