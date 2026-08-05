namespace AircraftMaintenanceOperations.Infrastructure.Persistence.Configurations;

public class WorkOrderConfiguration : IEntityTypeConfiguration<WorkOrder>
{
    public void Configure(EntityTypeBuilder<WorkOrder> builder)
    {
        builder.HasOne(wo => wo.Technician)
            .WithMany()
            .HasForeignKey(wo => wo.AssignedTechnicianId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(wo => wo.InventoryUsages)
            .WithOne(iu => iu.WorkOrder)
            .HasForeignKey(iu => iu.WorkOrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(wo => wo.MaintenanceRequestId);
        builder.HasIndex(wo => wo.AssignedTechnicianId);

        builder.Property(wo => wo.WorkOrderStatus).HasConversion<string>().IsRequired();
        builder.Property(wo => wo.EstimatedCompletionDate).IsRequired();
        builder.Property(wo => wo.EstimatedCompletionPercent).HasPrecision(5, 2).IsRequired();
        builder.Property(wo => wo.LaborNotes).HasConversion<string>().IsRequired().HasMaxLength(1000);
        builder.Property(wo => wo.ActualCompletionPercent).HasPrecision(5, 2);
        builder.Property(wo => wo.LaborHours).HasPrecision(8, 2);
    }
}
