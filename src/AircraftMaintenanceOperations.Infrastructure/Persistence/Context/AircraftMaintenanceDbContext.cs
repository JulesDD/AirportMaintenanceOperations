namespace AircraftMaintenanceOperations.Infrastructure.Persistence.Context;

public class AircraftMaintenanceDbContext : DbContext
{
    public AircraftMaintenanceDbContext(DbContextOptions<AircraftMaintenanceDbContext> options) : base(options)
    {
    }

    public DbSet<Aircraft> Aircrafts => Set<Aircraft>();
    public DbSet<Pilot> Pilots => Set<Pilot>();
    public DbSet<Technician> Technicians => Set<Technician>();
    public DbSet<MaintenanceRequest> MaintenanceRequests => Set<MaintenanceRequest>();
    public DbSet<WorkOrder> WorkOrders => Set<WorkOrder>();
    public DbSet<InventoryPart> InventoryParts => Set<InventoryPart>();
    public DbSet<InventoryUsage> InventoryUsages => Set<InventoryUsage>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AircraftMaintenanceDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
