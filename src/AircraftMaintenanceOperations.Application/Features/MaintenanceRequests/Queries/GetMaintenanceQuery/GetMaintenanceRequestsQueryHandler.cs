namespace AircraftMaintenanceOperations.Application.Features.MaintenanceRequests.Queries.GetMaintenanceQuery;

public record GetMaintenanceRequestsQueryHandler(IAircraftMaintenanceDbContext dbContext) : IQueryHandler<GetMaintenanceRequestsQuery, GetMaintenanceResult>
{
    public async Task<GetMaintenanceResult> Handle(GetMaintenanceRequestsQuery query, CancellationToken cancellationToken)
    {

        var mQuery = dbContext.MaintenanceRequests.AsNoTracking();
        if(!string.IsNullOrWhiteSpace(query.RequestedBy)) mQuery = mQuery.Where(mq => mq.RequestedBy == query.RequestedBy);
        if(query.Status.HasValue) mQuery = mQuery.Where(mq => mq.MaintenanceRequestStatus == query.Status);
        if(query.Priority.HasValue) mQuery = mQuery.Where(mq => mq.MaintenancePriority == query.Priority);

        // project the results to DTO
        var maintenanceRequests = await mQuery
            .Select(mq => new MaintenanceRequestDto
            (
                mq.RequestNumber,
                mq.Title,
                mq.Description,
                mq.AircraftId,
                mq.RequestedBy,
                mq.MaintenancePriority,
                mq.MaintenanceRequestStatus,
                mq.DueDate,
                mq.RequestedDate
            ))
            .ToListAsync(cancellationToken);

        return new GetMaintenanceResult(maintenanceRequests);
    }
}
