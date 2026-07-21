namespace AircraftMaintenanceOperations.Application.Features.Aircraft.Queries.GetAircraft;

public record GetAircraftsHandler(IAircraftMaintenanceDbContext dbContext) : IQueryHandler<GetAircraftsQuery, GetAircraftsResult>
{
    public async Task<GetAircraftsResult> Handle(GetAircraftsQuery query, CancellationToken cancellationToken)
    {
        var aircrafts = await dbContext.Aircrafts
            .Include(a => a.Year)
            .OrderBy(a => a.TailNumber)
            .ToListAsync(cancellationToken);

        return new GetAircraftsResult(aircrafts.Select(a => new AircraftDto(
            a.TailNumber,
            a.Manufacturer,
            a.Model,
            a.SerialNumber,
            a.Year)));
    }
}
