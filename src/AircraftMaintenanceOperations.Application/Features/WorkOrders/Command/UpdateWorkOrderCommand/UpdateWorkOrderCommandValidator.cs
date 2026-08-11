namespace AircraftMaintenanceOperations.Application.Features.WorkOrders.Command.UpdateWorkOrderCommand;

public class UpdateWorkOrderCommandValidator : AbstractValidator<UpdateWorkOrderCommand>
{
    public UpdateWorkOrderCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(200);
        RuleFor(x => x.WorkOrderPriority).IsInEnum();
        RuleFor(x => x.EstimatedCompletionDate).GreaterThanOrEqualTo(DateTime.UtcNow).WithMessage("Estimated completion date must be after today's date.");
    }
}
