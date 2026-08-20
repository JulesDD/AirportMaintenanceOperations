namespace AircraftMaintenanceOperations.Application.Features.Login.Commands.CreateLogin;

public record CreateLoginCommand(string UserName, string Password) : ICommand<CreateLoginCommandResult>;
public record CreateLoginCommandResult(LoginDto LoginDto);
