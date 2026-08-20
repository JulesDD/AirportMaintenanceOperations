namespace AircraftMaintenanceOperations.Infrastructure.Authentication;

public class IdentityAuthenticationService(UserManager<ApplicationUser> userManager) : IAuthenticationService
{
    public async Task<AuthenticationResult?> AuthenticateAsync(string userName, string password)
    {
        var user = await userManager.FindByNameAsync(userName);
        if (user is null) return null;

        var passwordValid = await userManager.CheckPasswordAsync(user, password);
        if (!passwordValid) return null;

        var roles = await userManager.GetRolesAsync(user);

        return new AuthenticationResult(
            user.Id,
            user.UserName!,
            roles);
    }
}
