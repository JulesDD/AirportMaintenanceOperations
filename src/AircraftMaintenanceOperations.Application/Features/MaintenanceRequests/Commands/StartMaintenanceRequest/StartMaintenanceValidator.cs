namespace AircraftMaintenanceOperations.Application.Features.MaintenanceRequests.Commands.StartMaintenanceRequest;

public class StartMaintenanceValidator : AbstractValidator<StartMaintenanceCommand>
{
    public StartMaintenanceValidator()
    {
        RuleFor(mr => mr.Id).NotEmpty().WithMessage("Maintenance Request ID is required.");
    }
   
}