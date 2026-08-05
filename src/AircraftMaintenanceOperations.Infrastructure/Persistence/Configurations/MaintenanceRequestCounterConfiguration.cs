namespace AircraftMaintenanceOperations.Infrastructure.Persistence.Configurations;

public class MaintenanceRequestCounterConfiguration : IEntityTypeConfiguration<MaintenanceRequestCounter>
{
    public void Configure(EntityTypeBuilder<MaintenanceRequestCounter> builder)
    {
        builder.ToTable("MaintenanceRequestCounters");
        builder.HasIndex(m => m.Year).IsUnique();
        builder.Property(x => x.RowVersion).IsRowVersion();
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Year).IsRequired();
        builder.Property(x => x.CurrentNumber).IsRequired();
    }
}
