namespace AircraftMaintenanceOperations.Infrastructure.Extensions;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Add DbContext
        services.AddDbContext<AircraftMaintenanceDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("AircraftMaintenanceConnection"));
        });
        // Add repositories
        //services.AddScoped<IAircraftRepository, AircraftRepository>();
        //services.AddScoped<IWorkOrderRepository, WorkOrderRepository>();
        //services.AddScoped<IInventoryRepository, InventoryRepository>();
        //services.AddScoped<ICurrentUserService, CurrentUserService>();
        // Add other infrastructure services as needed
        return services;
    }
}
