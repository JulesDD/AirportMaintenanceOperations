namespace AircraftMaintenanceOperations.Application.Features.WorkOrders.Queries.GetWorkOrderQuery;

public record GetWorkOrderQuery : IQuery<GetWorkOrderQueryResult>;
public record GetWorkOrderQueryResult(IEnumerable<WorkOrderDto> WorkOrders);