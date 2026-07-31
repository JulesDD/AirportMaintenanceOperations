namespace AircraftMaintenanceOperations.Application.Features.MaintenanceRequests.Commands.CloseMaintenanceRequest;

public class CloseMaintenanceValidator : AbstractValidator<CloseMaintenanceCommand>
{
    public CloseMaintenanceValidator()
    {
        RuleFor(mr => mr.Id).NotEmpty().WithMessage("Maintenance Request ID is required.");
    }
   
}