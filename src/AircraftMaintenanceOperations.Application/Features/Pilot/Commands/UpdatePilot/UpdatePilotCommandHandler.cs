namespace AircraftMaintenanceOperations.Application.Features.Pilot.Commands.UpdatePilot;

public class UpdatePilotCommandHandler(IAircraftMaintenanceDbContext dbContext) : ICommandHandler<UpdatePilotCommand, UpdatePilotResult>
{
    public async Task<UpdatePilotResult> Handle(UpdatePilotCommand command, CancellationToken cancellationToken)
    {
        var pilot = await dbContext.Pilots.FindAsync([command.Id], cancellationToken: cancellationToken);
        if (pilot == null) return new UpdatePilotResult(false);

        pilot.Update(
            command.FirstName,
            command.LastName,
            command.Email,
            command.PhoneNumber,
            command.Rank, 
            command.LicenseNumber
            );
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdatePilotResult(true);
    }
}
