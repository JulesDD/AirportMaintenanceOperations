namespace AircraftMaintenanceOperations.Application.Features.MaintenanceRequests.Commands.ArchiveMaintenanceRequest;

public class ArchiveMaintenanceCommandValidator : AbstractValidator<ArchiveMaintenanceCommand>
{
    public ArchiveMaintenanceCommandValidator()
    {
        RuleFor(dm => dm.MaintenanceRequestId).NotEmpty().WithMessage("Maintenance ID is required.");
    }
}