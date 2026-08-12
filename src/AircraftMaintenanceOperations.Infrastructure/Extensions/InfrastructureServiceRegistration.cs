using AircraftMaintenanceOperations.Infrastructure.Services;

namespace AircraftMaintenanceOperations.Infrastructure.Extensions;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Add DbContext
        services.AddDbContext<AircraftMaintenanceDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("AircraftMaintenanceConnection"));
        });

        services.AddScoped<IAircraftMaintenanceDbContext>(provider => provider.GetRequiredService<AircraftMaintenanceDbContext>());
        services.AddScoped<INumberGenerator, NumberGeneratorService>();
        // Add repositories
        //services.AddScoped<IAircraftRepository, AircraftRepository>();
        //services.AddScoped<IWorkOrderRepository, WorkOrderRepository>();
        //services.AddScoped<IInventoryRepository, InventoryRepository>();
        //services.AddScoped<ICurrentUserService, CurrentUserService>();
        // Add other infrastructure services as needed
        return services;
    }
}
