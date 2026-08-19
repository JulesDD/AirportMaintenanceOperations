namespace AircraftMaintenanceOperations.Application.Features.Authentication.Commands.CreateLogin;

public record CreateLoginCommand(string Email, string Password) : ICommand<CreateLoginCommandResult>;
public record CreateLoginCommandResult(IEnumerable<LoginDto> LoginDtos);
