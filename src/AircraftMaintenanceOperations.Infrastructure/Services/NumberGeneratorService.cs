namespace AircraftMaintenanceOperations.Infrastructure.Services;

public class NumberGeneratorService : INumberGenerator
{
    private readonly IAircraftMaintenanceDbContext dbContext;
    private static int currentYear => DateTime.UtcNow.Year;

    public NumberGeneratorService(IAircraftMaintenanceDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<string> GenerateMaintenanceRequestNumberAsync()
    {
        var counter = await dbContext.MaintenanceRequestCounters.FirstOrDefaultAsync(c => c.Year == currentYear);

        if (counter is null)
        {
            counter = new MaintenanceRequestCounter(currentYear);
            dbContext.MaintenanceRequestCounters.Add(counter);
        }

        var nextNumber = counter.GetNextNumber();

        await dbContext.SaveChangesAsync();

        return $"MR-{counter.Year}-{nextNumber:D6}";
    }

    public async Task<string> GenerateWorkOrderNumberAsync()
    {
        var counter = await dbContext.WorkOrderCounters.FirstOrDefaultAsync(c => c.Year == currentYear);

        if (counter is null)
        {
            counter = new WorkOrderCounter(currentYear);
            dbContext.WorkOrderCounters.Add(counter);
        }

        var nextNumber = counter.GetNextNumber();

        await dbContext.SaveChangesAsync();

        return $"WO-{counter.Year}-{nextNumber:D6}";
    }
}