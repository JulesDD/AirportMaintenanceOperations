namespace AircraftMaintenanceOperations.Infrastructure.Persistence.Context;

public class AircraftMaintenanceDbContext : DbContext
{
    public AircraftMaintenanceDbContext(DbContextOptions<AircraftMaintenanceDbContext> options) : base(options)
    {
    }

    public DbSet<Aircraft> Aircraft { get; set; }
    public DbSet<Pilot> Pilots { get; set; }
    public DbSet<Technician> Technicians { get; set; }
    public DbSet<MaintenanceRequest> MaintenanceRequests { get; set; }
    public DbSet<WorkOrder> WorkOrders { get; set; }
    public DbSet<InventoryPart> InventoryParts { get; set; }
    public DbSet<InventoryUsage> InventoryUsages { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AircraftMaintenanceDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
