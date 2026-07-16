namespace AircraftMaintenanceOperations.Infrastructure.Persistence.Configurations;

public class AircraftConfiguration : IEntityTypeConfiguration<Aircraft>
{
    public void Configure(EntityTypeBuilder<Aircraft> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasMany(a => a.MaintenanceRequests)
            .WithOne()
            .HasForeignKey(mr => mr.AircraftId)
            .OnDelete(DeleteBehavior.Cascade);


        builder.HasIndex(a => a.CurrentPilotId);
        builder.HasIndex(a => a.TailNumber).IsUnique();

        builder.Property(a => a.TailNumber).IsRequired().HasMaxLength(6);
        builder.Property(a => a.Manufacturer).IsRequired().HasMaxLength(50);
        builder.Property(a => a.Model).IsRequired().HasMaxLength(50);
        builder.Property(a => a.Year).IsRequired();
        builder.Property(a => a.SerialNumber).IsRequired().HasMaxLength(20);
        builder.Property(a => a.CurrentAirport).IsRequired().HasMaxLength(4);
        builder.Property(a => a.Status).IsRequired().HasConversion<string>();
    }
}
