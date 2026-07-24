namespace AircraftMaintenanceOperations.API.Extensions;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        // Here you would typically register your application services, such as MediatR handlers, validators, etc.
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        return services;
    }
}
public static class WebApplicationExtensions
{
    public static WebApplication UseApi(this WebApplication app)
    {
        app.UseSwagger();

        app.UseSwaggerUI();

        app.MapCarter();

        return app;
    }
}
