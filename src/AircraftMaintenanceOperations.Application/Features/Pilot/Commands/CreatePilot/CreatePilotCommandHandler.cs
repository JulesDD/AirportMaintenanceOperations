namespace AircraftMaintenanceOperations.Application.Features.Pilot.Commands.CreatePilot;

public class CreatePilotCommandHandler(IAircraftMaintenanceDbContext dbContext) : ICommandHandler<CreatePilotCommand, CreatePilotCommandResult>
{
    public async Task<CreatePilotCommandResult> Handle(CreatePilotCommand command, CancellationToken cancellationToken)
    {
        var pilot = Domain.Entities.Pilot.Create
        (
            command.Rank,
            command.LicenseNumber
        );

        dbContext.Pilots.Add(pilot);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreatePilotCommandResult(pilot.Id);
    }
}
