namespace AircraftMaintenanceOperations.Infrastructure.Persistence.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasIndex(x => x.DomainUserId).IsUnique();
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.DomainUserId).OnDelete(DeleteBehavior.Restrict);  
    }
}
