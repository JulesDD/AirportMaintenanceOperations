namespace AircraftMaintenanceOperations.Application.Features.WorkOrders.Command.ArchiveWorkOrderCommand;

public class ArchiveWorkOrderCommandValidator : AbstractValidator<ArchiveWorkOrderCommand>
{
    public ArchiveWorkOrderCommandValidator()
    {
        RuleFor(dm => dm.WorkOrderId).NotEmpty().WithMessage("Work Order ID is required.");
    }
}
