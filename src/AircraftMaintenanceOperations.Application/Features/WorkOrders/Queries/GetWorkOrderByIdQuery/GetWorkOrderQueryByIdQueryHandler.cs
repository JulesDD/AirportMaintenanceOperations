namespace AircraftMaintenanceOperations.Application.Features.WorkOrders.Queries.GetWorkOrderByIdQuery;

public record GetWorkOrderByIdQueryHandler(IAircraftMaintenanceDbContext dbContext) : IQueryHandler<GetWorkOrderQueryByIdQuery, GetWorkOrderByIdQueryResult>
{
    public async Task<GetWorkOrderByIdQueryResult> Handle(GetWorkOrderQueryByIdQuery query, CancellationToken cancellationToken)
    {
        
        var order = await dbContext.WorkOrders
            .Where(wo => wo.Id == query.WorkOrderId)
            .FirstOrDefaultAsync(cancellationToken);

        return new GetWorkOrderByIdQueryResult(order == null ? null : new WorkOrderDto(
            order.Id,
            order.WorkOrderNumber,
            order.MaintenanceRequestId,
            order.AircraftId,
            order.AssignedTechnicianId,
            order.WorkOrderPriority,
            order.WorkOrderStatus,
            order.EstimatedCompletionDate));
    }
}
