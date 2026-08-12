namespace AircraftMaintenanceOperations.Application.Features.Technician.Commands.UpdateTechnician;

public class UpdateTechnicianCommandValidator : AbstractValidator<UpdateTechnicianCommand>
{
    public UpdateTechnicianCommandValidator()
    {
        RuleFor(x => x.TechnicianId).NotEmpty().WithMessage("Technician ID is required");
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required");
        RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required");
        RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("A valid email address is required");
        RuleFor(x => x.YearsOfExperience).GreaterThanOrEqualTo(0).WithMessage("Years of experience cannot be negative");
    }
}
