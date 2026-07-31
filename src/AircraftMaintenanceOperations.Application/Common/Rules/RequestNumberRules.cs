namespace AircraftMaintenanceOperations.Application.Common.Rules;

public class RequestNumberRules(IAircraftMaintenanceDbContext dbContext)
{
    public async Task<bool> BeUniqueRequestNumber(string requestNumber, CancellationToken cancellationToken)
    {
        return !await dbContext.MaintenanceRequests.AnyAsync(mr => mr.RequestNumber == requestNumber, cancellationToken);
    }
}