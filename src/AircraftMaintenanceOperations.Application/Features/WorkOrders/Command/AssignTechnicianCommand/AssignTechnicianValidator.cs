namespace AircraftMaintenanceOperations.Application.Features.WorkOrders.Command.AssignTechnicianCommand;

public class AssignTechnicianValidator : AbstractValidator<AssignTechnicianCommand>
{
    public AssignTechnicianValidator()
    {
        RuleFor(x => x.TechnicianId).NotEmpty().WithMessage("Technician should not be null");
        RuleFor(x => x.WorkOrderId).NotEmpty().WithMessage("WorkOrderId should not be null");
    }
}
