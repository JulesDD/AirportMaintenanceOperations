namespace AircraftMaintenanceOperations.Application.Features.AssignPilot.Command;

public class AssignPilotHandler(IAircraftMaintenanceDbContext dbContext) : ICommandHandler<AssignPilotCommand, AssignPilotResult>
{
    public async Task<AssignPilotResult> Handle(AssignPilotCommand command, CancellationToken cancellationToken)
    {
        //load pilotId from db
        var pilot = await dbContext.Pilots.FirstOrDefaultAsync(x => x.Id == command.PilotId);

        //load aircraft from db
        var aircraft = await dbContext.Aircrafts.FirstOrDefaultAsync(x => x.Id == command.AircraftId);

        if (aircraft is null || pilot is null) return new AssignPilotResult(false);

        var assignedPilot = aircraft.AssignPilot(pilot);
        
        if (assignedPilot.IsSuccess is true)
        {
            await dbContext.SaveChangesAsync(cancellationToken);
            return new AssignPilotResult(true);
        }
        else return new AssignPilotResult(false);

    }
}
