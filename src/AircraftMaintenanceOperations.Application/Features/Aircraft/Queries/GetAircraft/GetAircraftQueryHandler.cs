namespace AircraftMaintenanceOperations.Application.Features.Aircraft.Queries.GetAircraft;

public record GetAircraftQueryHandler(IAircraftMaintenanceDbContext dbContext) : IQueryHandler<GetAircraftQuery, GetAircraftsResult>
{
    public async Task<GetAircraftsResult> Handle(GetAircraftQuery query, CancellationToken cancellationToken)
    {
        var aircrafts = await dbContext.Aircrafts
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
