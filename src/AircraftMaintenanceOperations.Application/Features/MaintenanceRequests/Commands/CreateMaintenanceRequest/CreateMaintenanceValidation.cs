namespace AircraftMaintenanceOperations.Application.Features.MaintenanceRequests.Commands.CreateMaintenanceRequest;

public class CreateMaintenanceValidation : AbstractValidator<CreateMaintenanceCommand>
{
    public CreateMaintenanceValidation() 
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Please provide a title for maintenance request.");
        RuleFor(x => x.RequestNumber).NotEmpty().WithMessage("Please provide a request number.");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Please provide some description in the request.");
        RuleFor(x => x.AircraftId).NotEmpty().WithMessage("Please provide an aircraft ID number");
        RuleFor(x => x.DueDate).GreaterThanOrEqualTo(DateTime.Now).WithMessage("The due date must be a day ahead from the date it was created.");
        RuleFor(x => x.RequestedBy).NotEmpty().WithMessage("Someone needs to request this request.");
        //RuleFor(x => x.RequestNumber).MustAsync(BeUniqueNumber).WithMessage("Request number must be unique.");
    }

    //private async Task<bool> BeUniqueNumber(string requestNumber, CancellationToken cancellationToken)
    //{
    //    return !await 
    //}
}
