namespace AircraftMaintenanceOperations.Infrastructure.Authentication;

public class ApplicationUser : IdentityUser<Guid>
{
    public Guid DomainUserId { get; set; }
}
