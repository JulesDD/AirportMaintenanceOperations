namespace AircraftMaintenanceOperations.Application.Features.WorkOrders.Queries.GetWorkOrderByIdQuery;

public record GetWorkOrderQueryByIdQuery(Guid WorkOrderId) : IQuery<GetWorkOrderByIdQueryResult>;
public record GetWorkOrderByIdQueryResult(WorkOrderDto? WorkOrder);
