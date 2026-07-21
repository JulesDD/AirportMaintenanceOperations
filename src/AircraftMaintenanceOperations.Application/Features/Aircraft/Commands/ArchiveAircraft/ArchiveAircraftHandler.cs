using AircraftMaintenanceOperations.Domain.Enums;

namespace AircraftMaintenanceOperations.Application.Features.Aircraft.Commands.ArchiveAircraft;

public class ArchiveAircraftHandler(IAircraftMaintenanceDbContext dbContext) : ICommandHandler<ArchiveAircraftCommand, ArchiveAircraftResult>
{
    public async Task<ArchiveAircraftResult> Handle(ArchiveAircraftCommand command, CancellationToken cancellationToken)
    {
        var aircraft = await dbContext.Aircrafts.FindAsync([command.AircraftId], cancellationToken: cancellationToken);
        if (aircraft is null) return new ArchiveAircraftResult(false);

        //dbContext.Aircraft.Archive(aircraft);

        // archive the aircraft table by setting the status to Archived 
        aircraft.Archive();
        await dbContext.SaveChangesAsync(cancellationToken);

        return new ArchiveAircraftResult(true);
    }
}
