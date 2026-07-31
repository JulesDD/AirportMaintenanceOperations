namespace AircraftMaintenanceOperations.Application.Features.MaintenanceRequests.Commands.DeleteMaintenanceRequest;

public class DeleteMaintenanceCommandValidator : AbstractValidator<DeleteMaintenanceCommand>
{
    public DeleteMaintenanceCommandValidator()
    {
        RuleFor(dm => dm.Id).NotEmpty().WithMessage("Maintenance ID is required.");
    }
}