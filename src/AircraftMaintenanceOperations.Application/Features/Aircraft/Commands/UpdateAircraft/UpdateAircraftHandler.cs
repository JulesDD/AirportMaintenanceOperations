namespace AircraftMaintenanceOperations.Application.Features.Aircraft.Commands.UpdateAircraft;

public class UpdateAircraftHandler(IAircraftMaintenanceDbContext dbContext) : ICommandHandler<UpdateAircraftCommand, UpdateAircraftResult>
{
    public async Task<UpdateAircraftResult> Handle(UpdateAircraftCommand command, CancellationToken cancellationToken)
    {
        var aircraft = await dbContext.Aircrafts.FindAsync([command.Id], cancellationToken: cancellationToken);
        if(aircraft == null) return new UpdateAircraftResult(false);

        var result =aircraft.UpdateFlightHours(command.flightHours);
        if(!result.IsSuccess) return new UpdateAircraftResult(false);

        aircraft.Update(
            command.currentAirport,
            command.flightHours,
            command.lastMaintenanceDate,
            command.nextMaintenanceDate);

        await dbContext.SaveChangesAsync(cancellationToken);
        return new UpdateAircraftResult(true);
    }
}
