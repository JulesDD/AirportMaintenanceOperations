using AircraftMaintenanceOperations.Domain.Common;

namespace AircraftMaintenanceOperations.Application.Features.AssignPilot.Command;

public class AssignPilotHandler(IAircraftMaintenanceDbContext dbContext) : ICommandHandler<AssignPilotCommand, AssignPilotResult>
{
    public async Task<AssignPilotResult> Handle(AssignPilotCommand command, CancellationToken cancellationToken)
    {
        //load pilotId from db
        var pilot = await dbContext.Pilots.FindAsync([command.PilotId], cancellationToken);

        //load aircraft from db
        var aircraft = await dbContext.Aircrafts.FindAsync([command.AircraftId], cancellationToken);

        if (aircraft is null || pilot is null) return new AssignPilotResult(false);

        var assignedPilot = aircraft.AssignPilot(pilot);
        
        if (!assignedPilot.IsSuccess) return new AssignPilotResult(false);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new AssignPilotResult(true);
    }
}
