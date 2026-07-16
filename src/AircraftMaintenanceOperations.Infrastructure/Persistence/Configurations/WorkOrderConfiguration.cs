namespace AircraftMaintenanceOperations.Infrastructure.Persistence.Configurations;

public class WorkOrderConfiguration : IEntityTypeConfiguration<WorkOrder>
{
    public void Configure(EntityTypeBuilder<WorkOrder> builder)
    {
        builder.HasKey(wo => wo.Id);

        builder.HasOne<Technician>()
            .WithMany()
            .HasForeignKey(wo => wo.TechnicianId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany<InventoryUsage>()
            .WithOne()
            .HasForeignKey(iu => iu.WorkOrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(wo => wo.MaintenanceRequestId);
        builder.HasIndex(wo => wo.TechnicianId);

        builder.Property(wo => wo.Status).HasConversion<string>().IsRequired();
        builder.Property(wo => wo.EstimatedCompletionDate).IsRequired();
        builder.Property(wo => wo.EstimatedCompletionPercent).HasPrecision(5, 2).IsRequired();
        builder.Property(wo => wo.LaborNotes).HasConversion<string>().IsRequired().HasMaxLength(1000);
    }
}
