namespace AircraftMaintenanceOperations.Application.Features.Pilot.Commands.UpdatePilot;

public class UpdatePilotCommandHandler(IAircraftMaintenanceDbContext dbContext) : ICommandHandler<UpdatePilotCommand, UpdatePilotCommandResult>
{
    public async Task<UpdatePilotCommandResult> Handle(UpdatePilotCommand command, CancellationToken cancellationToken)
    {
        var pilot = await dbContext.Pilots.FindAsync([command.PilotId], cancellationToken: cancellationToken);
        if (pilot == null) return new UpdatePilotCommandResult(false);

        pilot.Update(rank: pilot.Rank, licenseNumber: pilot.LicenseNumber);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdatePilotCommandResult(true);
    }
}
