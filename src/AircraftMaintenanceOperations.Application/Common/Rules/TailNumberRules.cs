namespace AircraftMaintenanceOperations.Application.Common.Rules;

public class TailNumberRules(IAircraftMaintenanceDbContext dbContext)
{
    public async Task<bool> BeUniqueTailNumber(string tailNumber, CancellationToken cancellationToken)
    {
        return !await dbContext.Aircrafts.AnyAsync(a => a.TailNumber == tailNumber, cancellationToken);
    }
}