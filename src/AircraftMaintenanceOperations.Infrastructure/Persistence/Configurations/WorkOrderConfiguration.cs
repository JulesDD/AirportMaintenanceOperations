namespace AircraftMaintenanceOperations.Infrastructure.Persistence.Configurations;

public class WorkOrderConfiguration : IEntityTypeConfiguration<WorkOrder>
{
    public void Configure(EntityTypeBuilder<WorkOrder> builder)
    {
        builder.HasMany(wo => wo.InventoryUsages)
            .WithOne(iu => iu.WorkOrder)
            .HasForeignKey(iu => iu.WorkOrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(wo => wo.MaintenanceRequestId);
        builder.HasIndex(wo => wo.AssignedTechnicianId);
        builder.HasIndex(wo => wo.AircraftId);

        builder.Property(wo => wo.WorkOrderStatus).HasConversion<string>().IsRequired();
        builder.Property(wo => wo.EstimatedCompletionDate).IsRequired();
        builder.Property(wo => wo.LaborNotes).HasConversion<string>().IsRequired().HasMaxLength(1000);
        builder.Property(wo => wo.LaborHours).HasPrecision(8, 2);

        builder.HasOne(wo => wo.Aircraft)
            .WithMany(a => a.WorkOrders)
            .HasForeignKey(wo => wo.AircraftId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
