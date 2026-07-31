namespace AircraftMaintenanceOperations.Application.Features.MaintenanceRequests.Queries.SearchMaintenanceQuery;

public record SearchMaintenanceQueryHandler(IAircraftMaintenanceDbContext dbContext) : IQueryHandler<SearchMaintenanceQuery, SearchMaintenanceResult>
{
    public Task<SearchMaintenanceResult> Handle(SearchMaintenanceQuery query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}