namespace AircraftMaintenanceOperations.Infrastructure.Persistence.Configurations;

public class MaintenanceRequestConfiguration : IEntityTypeConfiguration<MaintenanceRequest>
{
    public void Configure(EntityTypeBuilder<MaintenanceRequest> builder)
    {
        builder.HasKey(mr => mr.Id);

        builder.HasOne<WorkOrder>()
            .WithOne(wo => wo.MaintenanceRequest)
            .HasForeignKey<WorkOrder>(wo => wo.MaintenanceRequestId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(mr => mr.AircraftId);
        builder.HasIndex(mr => mr.ReportedByUserId);

        builder.Property(mr => mr.Description).IsRequired().HasMaxLength(1000);
    }
}
