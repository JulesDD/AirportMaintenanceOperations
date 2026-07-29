namespace AircraftMaintenanceOperations.Application.Features.Aircraft.Commands.UpdateAircraft;

public class UpdateAircraftValidator : AbstractValidator<UpdateAircraftCommand>
{
    public UpdateAircraftValidator()
    {
        RuleFor(x => x.currentAirport).MaximumLength(3).When(x => x.currentAirport is not null);
        RuleFor(x => x.currentAirport).NotEmpty().WithMessage("Please place the last location the ");

        RuleFor(x => x.flightHours).GreaterThanOrEqualTo(0).WithMessage("Flight hours should be greater then Zero");

        RuleFor(x => x.nextMaintenanceDate).GreaterThan(x => x.lastMaintenanceDate).WithMessage("Next date must be greater than the last date.");
        RuleFor(x => x.lastMaintenanceDate).LessThan(x => x.nextMaintenanceDate).WithMessage("Last date must be less then the next date.");
    }

}
