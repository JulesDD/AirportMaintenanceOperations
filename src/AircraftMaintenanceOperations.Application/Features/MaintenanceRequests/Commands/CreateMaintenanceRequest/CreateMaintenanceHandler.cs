namespace AircraftMaintenanceOperations.Application.Features.MaintenanceRequests.Commands.CreateMaintenanceRequest;

public class CreateMaintenanceHandler(IAircraftMaintenanceDbContext dbContext) : ICommandHandler<CreateMaintenanceCommand, CreatedMaintenanceResult>
{
    public async Task<CreatedMaintenanceResult> Handle(CreateMaintenanceCommand command, CancellationToken cancellationToken)
    {
        if (await dbContext.MaintenanceRequests.AnyAsync(x => x.RequestNumber == command.RequestNumber, cancellationToken)) throw new InvalidOperationException("A request with the same number already exists.");
        if (!await dbContext.Aircrafts.AnyAsync(x => x.Id == command.AircraftId, cancellationToken)) throw new InvalidOperationException("The specified aircraft does not exist.");
        var maintenanceRequest = MaintenanceRequest.Create(
            command.RequestNumber,
            command.Title,
            command.AircraftId,
            command.Description,
            command.RequestedBy,
            command.DueDate
        );

        dbContext.MaintenanceRequests.Add(maintenanceRequest);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreatedMaintenanceResult(maintenanceRequest.Id); 
    }
}
