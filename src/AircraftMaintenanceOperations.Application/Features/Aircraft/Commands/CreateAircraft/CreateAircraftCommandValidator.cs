namespace AircraftMaintenanceOperations.Application.Features.Aircraft.Commands.CreateAircraft;

public class CreateAircraftCommandValidator : AbstractValidator<CreateAircraftCommand>
{
    private readonly TailNumberRules _tailNumberRules;
    public CreateAircraftCommandValidator(TailNumberRules tailNumberRules)
    {
        _tailNumberRules = tailNumberRules;

        RuleFor(x => x.TailNumber).NotEmpty().WithMessage("Tail number is required.");
        RuleFor(x => x.TailNumber).MustAsync(_tailNumberRules.BeUniqueTailNumber).WithMessage("Tail number must be unique.");
        RuleFor(x => x.Manufacturer).NotEmpty().WithMessage("Manufacturer is required.");
        RuleFor(x => x.Model).NotEmpty().WithMessage("Model is required.");
        RuleFor(x => x.SerialNumber).NotEmpty().WithMessage("Serial number is required.");
        RuleFor(x => x.YearOfManufacture).InclusiveBetween(2015, DateTime.Now.Year).WithMessage($"Year of manufacture must be between 2015 and {DateTime.Now.Year}.");
    }
}
