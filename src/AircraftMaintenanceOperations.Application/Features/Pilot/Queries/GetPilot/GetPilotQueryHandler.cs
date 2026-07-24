namespace AircraftMaintenanceOperations.Application.Features.Pilot.Queries.GetPilot;

public record GetPilotQueryHandler(IAircraftMaintenanceDbContext dbContext) : IQueryHandler<GetPilotQuery, GetPilotQueryResult>
{
    public async Task<GetPilotQueryResult> Handle(GetPilotQuery query, CancellationToken cancellationToken)
    {
        var pilots = await dbContext.Pilots
            .OrderBy(p => p.Rank) 
            .ToListAsync(cancellationToken);

        return new GetPilotQueryResult(pilots.Select(p => new PilotDto(
            p.Rank,
            p.LicenseNumber)));
    }
}
