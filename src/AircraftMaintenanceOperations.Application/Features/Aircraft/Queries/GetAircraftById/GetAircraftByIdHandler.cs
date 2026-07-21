namespace AircraftMaintenanceOperations.Application.Features.Aircraft.Queries.GetAircraftById;

public class GetAircraftByIdHandler(IAircraftMaintenanceDbContext dbContext) : IQueryHandler<GetAircraftByIdQuery, GetAircraftByIdResult>
{
    public async Task<GetAircraftByIdResult> Handle(GetAircraftByIdQuery query, CancellationToken cancellationToken)
    {
        var aircrafts = await dbContext.Aircrafts
            .Where(a => a.Id == query.AircraftId)
            .OrderBy(a => a.TailNumber)
            .FirstOrDefaultAsync(cancellationToken);

        return new GetAircraftByIdResult(aircrafts == null ? null : new AircraftDto(aircrafts.TailNumber,
            aircrafts.Manufacturer,
            aircrafts.Model, 
            aircrafts.SerialNumber,
            aircrafts.Year));
    }
}
