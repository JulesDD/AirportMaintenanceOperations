namespace AircraftMaintenanceOperations.Application.Features.MaintenanceRequests.Queries.GetMaintenanceQueryById;

public record GetMaintenanceQueryByIdHandler(IAircraftMaintenanceDbContext dbContext) : IQueryHandler<GetMaintenanceQueryById, GetMaintenanceQueryByIdResult>
{
    public async Task<GetMaintenanceQueryByIdResult> Handle(GetMaintenanceQueryById query, CancellationToken cancellationToken)
    {
        var mQuery = await dbContext.MaintenanceRequests
            .Where(mq => mq.Id == query.MaintenanceRequestId)
            .FirstOrDefaultAsync(cancellationToken);

        return new GetMaintenanceQueryByIdResult(mQuery == null ? null : new MaintenanceRequestDto(
            mQuery.RequestNumber,
            mQuery.Title,
            mQuery.Description,
            mQuery.AircraftId,
            mQuery.RequestedBy,
            mQuery.MaintenancePriority,
            mQuery.MaintenanceRequestStatus,
            mQuery.DueDate,
            mQuery.RequestedDate));
    }
}
