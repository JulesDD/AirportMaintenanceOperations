namespace AircraftMaintenanceOperations.Application.Interfaces;

public interface IAircraftMaintenanceDbContext
{
    DbSet<Aircraft> Aircrafts { get; }
    DbSet<Pilot> Pilots { get; }
    DbSet<Technician> Technicians { get; }
    DbSet<MaintenanceRequest> MaintenanceRequests { get; }
    DbSet<WorkOrder> WorkOrders { get; }
    DbSet<InventoryPart> InventoryParts { get; }
    DbSet<InventoryUsage> InventoryUsages { get; }
    DbSet<User> Users { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
