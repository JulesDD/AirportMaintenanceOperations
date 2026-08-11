namespace AircraftMaintenanceOperations.Application.Features.MaintenanceRequests.Commands.CreateMaintenanceRequest;

public class CreateMaintenanceHandler(IAircraftMaintenanceDbContext dbContext, INumberGenerator numberGenerator) : ICommandHandler<CreateMaintenanceCommand, CreatedMaintenanceResult>
{
    public async Task<CreatedMaintenanceResult> Handle(CreateMaintenanceCommand command, CancellationToken cancellationToken)
    {
        var requestNumber = await numberGenerator.GenerateMaintenanceRequestNumberAsync();

        if (!await dbContext.Aircrafts.AnyAsync(x => x.Id == command.AircraftId, cancellationToken)) throw new InvalidOperationException("The specified aircraft does not exist.");
        var maintenanceRequest = MaintenanceRequest.Create(
            requestNumber,
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
