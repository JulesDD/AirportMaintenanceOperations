namespace AircraftMaintenanceOperations.Application.Features.Pilot.Queries.GetPilotById;

public class GetPilotByIdQueryHandler(IAircraftMaintenanceDbContext dbContext) : IQueryHandler<GetPilotByIdQuery, GetPilotByIdQueryResult>
{
    public async Task<GetPilotByIdQueryResult> Handle(GetPilotByIdQuery query, CancellationToken cancellationToken)
    {
        var pilots = await dbContext.Pilots
            .Where(p => p.Id == query.PilotId)
            .OrderBy(p => p.Rank)
            .FirstOrDefaultAsync(cancellationToken);

        return new GetPilotByIdQueryResult(pilots == null ? null : new PilotDto(
            pilots.Rank,
            pilots.LicenseNumber));
    }
}
