namespace AircraftMaintenanceOperations.API.Endpoints.Login;

public class LoginEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/auth/login").WithTags("Auth");
    }
}
