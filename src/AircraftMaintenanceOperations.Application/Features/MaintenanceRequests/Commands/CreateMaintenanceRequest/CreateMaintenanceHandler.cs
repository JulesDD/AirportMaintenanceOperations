namespace AircraftMaintenanceOperations.Application.Features.MaintenanceRequests.Commands.CreateMaintenanceRequest;

public class CreateMaintenanceHandler(IAircraftMaintenanceDbContext dbContext) : ICommandHandler<CreateMaintenanceCommand, CreatedMaintenanceResult>
{
    public async Task<CreatedMaintenanceResult> Handle(CreateMaintenanceCommand command, CancellationToken cancellationToken)
    {
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
