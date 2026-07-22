namespace AircraftMaintenanceOperations.Application.Features.AssignPilot.Command;

public class AssignPilotCommandValidator : AbstractValidator<AssignPilotCommand>
{
    private readonly IAircraftMaintenanceDbContext _dbContext;
    public AssignPilotCommandValidator(IAircraftMaintenanceDbContext dbContext)
    {
        _dbContext = dbContext;

        RuleFor(x => x.PilotId).NotNull().WithMessage("Pilot should not be null");
        RuleFor(x => x.AircraftId).NotEmpty().WithMessage("AircraftId should not be null");
    }
}
