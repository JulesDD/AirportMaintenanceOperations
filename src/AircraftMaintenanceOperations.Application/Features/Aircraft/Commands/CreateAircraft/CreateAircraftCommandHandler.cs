namespace AircraftMaintenanceOperations.Application.Features.Aircraft.Commands.CreateAircraft;

public class CreateAircraftCommandHandler(IAircraftMaintenanceDbContext dbContext) : ICommandHandler<CreateAircraftCommand, CreateAircraftCommandResult>
{
    public async Task<CreateAircraftCommandResult> Handle(CreateAircraftCommand command, CancellationToken cancellationToken)
    {
        var aircraft = Domain.Entities.Aircraft.Create
        (
            command.TailNumber,
            command.Manufacturer,
            command.Model,      
            command.SerialNumber,
            command.YearOfManufacture,
            command.CurrentLocation
        );

        dbContext.Aircrafts.Add(aircraft);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateAircraftCommandResult(aircraft.Id);
    }

    
}
