namespace AircraftMaintenanceOperations.Application.Features.Technician.Commands.CreateTechnician;

public class CreateTechnicianCommandValidator : AbstractValidator<CreateTechnicianCommand>
{
    public CreateTechnicianCommandValidator()
    {
        RuleFor(x => x.EmployeeNumber).NotEmpty().WithMessage("Employee Number is required");
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required");
        RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Email is required");
        RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone Number is required");
        RuleFor(x => x.CertificationNumber).IsInEnum().WithMessage("Invalid Certification Level");
        RuleFor(x => x.YearsOfExperience).GreaterThanOrEqualTo(0).WithMessage("Years of Experience must be a positive number");
    }
}
