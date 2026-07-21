namespace AircraftMaintenanceOperations.Application.Features.Aircraft.Commands.CreateAircraft;

public class CreateAircraftHandler(IAircraftMaintenanceDbContext dbContext) : ICommandHandler<CreateAircraftCommand, CreateAircraftCommandResult>
{
    public async Task<CreateAircraftCommandResult> Handle(CreateAircraftCommand command, CancellationToken cancellationToken)
    {
        var aircraft = new Domain.Entities.Aircraft
        {
            TailNumber = command.TailNumber,
            Model = command.Model,
            Manufacturer = command.Manufacturer,
            SerialNumber = command.SerialNumber,
            Year = command.YearOfManufacture,
            CurrentAirport = command.CurrentLocation,
            Status = Domain.Enums.AircraftStatus.Grounded, // Assuming the aircraft is grounded when created
            FlightHours = 0, // Assuming the aircraft is new and has not flown yet
            CurrentPilotId = null // Assuming the aircraft is not assigned to any pilot when created
        };

        dbContext.Aircrafts.Add(aircraft);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateAircraftCommandResult(aircraft.Id);
    }

}
