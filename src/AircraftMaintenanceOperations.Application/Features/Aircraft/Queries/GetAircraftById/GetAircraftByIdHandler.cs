namespace AircraftMaintenanceOperations.Application.Features.Aircraft.Queries.GetAircraftById;

public class GetAircraftByIdHandler(IAircraftMaintenanceDbContext dbContext) : IQueryHandler<GetAircraftByIdQuery, GetAircraftByIdResult>
{
    public async Task<GetAircraftByIdResult> Handle(GetAircraftByIdQuery query, CancellationToken cancellationToken)
    {
        var aircrafts = await dbContext.Aircrafts
            .Where(a => a.Id == query.AircraftId)
            .OrderBy(a => a.TailNumber)
            .ToListAsync(cancellationToken);

        return new GetAircraftByIdResult(aircrafts.Select(a => new AircraftDto(
            a.TailNumber,
            a.Manufacturer,
            a.Model, 
            a.SerialNumber,
            a.Year)));
    }
}
