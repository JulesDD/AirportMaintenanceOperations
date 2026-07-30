namespace AircraftMaintenanceOperations.Application.Features.MaintenanceRequests.Commands.UpdatedMaintenanceRequest;

public class UpdateMaintenanceValidator : AbstractValidator<UpdateMaintenanceCommand>
{
    public UpdateMaintenanceValidator()
    {
        RuleFor(x => x.RequestNumber).MaximumLength(10).When(x => x.RequestNumber is not null);
        RuleFor(x => x.Title).MaximumLength(50).When(x => x.Title is not null);
        RuleFor(x => x.Description).MaximumLength(200).When(x => x.Description is not null);
        RuleFor(x => x.DueDate).GreaterThanOrEqualTo(DateTime.UtcNow).WithMessage("Due date must be after today's date.");
        RuleFor(x => x.RequestedDate).LessThan(DateTime.UtcNow).WithMessage("Request date must be after today's date. ");
        RuleFor(x => x.ClosedDate).LessThan(x => x.DueDate).WithMessage("Closed date cannot be less than the due date.");
    }
}
