namespace AircraftMaintenanceOperations.Application.Features.MaintenanceRequests.Commands.UpdatedMaintenanceRequest;

public class UpdateMaintenanceValidator : AbstractValidator<UpdateMaintenanceCommand>
{
    public UpdateMaintenanceValidator()
    {
        RuleFor(x => x.Title).MaximumLength(50).When(x => x.Title is not null);
        RuleFor(x => x.Description).MaximumLength(200).When(x => x.Description is not null);
        RuleFor(x => x.DueDate).GreaterThanOrEqualTo(DateTime.UtcNow).WithMessage("Due date must be after today's date.");
        RuleFor(x => x.ClosedDate).GreaterThanOrEqualTo(x => x.DueDate).WithMessage("Closed date cannot be less than the due date.");
    }
}
