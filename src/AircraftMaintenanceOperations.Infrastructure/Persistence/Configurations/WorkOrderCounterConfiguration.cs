namespace AircraftMaintenanceOperations.Infrastructure.Persistence.Configurations;

public class WorkOrderCounterConfiguration : IEntityTypeConfiguration<WorkOrderCounter>
{
    public void Configure(EntityTypeBuilder<WorkOrderCounter> builder)
    {
        builder.ToTable("WorkOrderCounters");
        builder.HasIndex(m => m.Year).HasDatabaseName("IX_WorkOrderCounter_Year").IsUnique();
        builder.Property(x => x.RowVersion).IsRowVersion();
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Year).IsRequired();
        builder.Property(x => x.CurrentNumber).HasColumnType("int");
    }
}
