namespace AircraftMaintenanceOperations.Application.Features.MaintenanceRequests.Queries.GetMaintenanceQuery;

public record GetMaintenanceQueryHandler(IAircraftMaintenanceDbContext dbContext) : IQueryHandler<GetMaintenanceQuery, GetMaintenanceResult>
{
    public async Task<GetMaintenanceResult> Handle(GetMaintenanceQuery query, CancellationToken cancellationToken)
    {
        var mQuery = await dbContext.MaintenanceRequests
            .AsNoTracking()
            .Select(mq => new MaintenanceRequestDto(
            mq.RequestNumber,
            mq.Title,
            mq.Description,
            mq.AircraftId,
            mq.RequestedBy,
            mq.MaintenancePriority,
            mq.MaintenanceRequestStatus,
            mq.DueDate,
            mq.RequestedDate))
            .ToListAsync(cancellationToken);

        return new GetMaintenanceResult(mQuery);
    }
}
