namespace AircraftMaintenanceOperations.Application.Features.Aircraft.Commands.CreateAircraft;

public class CreateAircraftCommandValidator : AbstractValidator<CreateAircraftCommand>
{
    private readonly IAircraftMaintenanceDbContext _dbContext;
    public CreateAircraftCommandValidator(IAircraftMaintenanceDbContext dbContext)
    {
        _dbContext = dbContext;

        RuleFor(x => x.TailNumber).NotEmpty().MustAsync(BeUniqueTailNumber).WithMessage("Tail number is required.");
        RuleFor(x => x.Manufacturer).NotEmpty().WithMessage("Manufacturer is required.");
        RuleFor(x => x.Model).NotEmpty().WithMessage("Model is required.");
        RuleFor(x => x.SerialNumber).NotEmpty().WithMessage("Serial number is required.");
        RuleFor(x => x.YearOfManufacture).InclusiveBetween(2015, DateTime.Now.Year).WithMessage($"Year of manufacture must be between 2015 and {DateTime.Now.Year}.");
    }

    private async Task<bool> BeUniqueTailNumber(string tailNumber, CancellationToken cancellationToken)
    {
        // return true if the tail number does not exist in the database, false otherwise

        return !await _dbContext.Aircraft.AnyAsync(a => a.TailNumber == tailNumber, cancellationToken);
    }
}
