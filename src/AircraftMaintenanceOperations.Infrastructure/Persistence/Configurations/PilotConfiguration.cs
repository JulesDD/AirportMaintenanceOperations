namespace AircraftMaintenanceOperations.Infrastructure.Persistence.Configurations;

public class PilotConfiguration : IEntityTypeConfiguration<Pilot>
{
    public void Configure(EntityTypeBuilder<Pilot> builder)
    {
        builder.HasIndex(x => x.LicenseNumber).IsUnique();

        builder.Property(x => x.Status)
                .HasConversion<string>();

        builder.Property(x => x.Rank)
               .HasMaxLength(50);

        builder.Property(x => x.LicenseNumber)
               .HasMaxLength(50);

        builder.HasOne<Aircraft>()
            .WithOne(a => a.CurrentPilot)
            .HasForeignKey<Aircraft>(x => x.CurrentPilotId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
