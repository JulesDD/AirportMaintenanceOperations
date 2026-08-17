namespace AircraftMaintenanceOperations.Application.Features.MaintenanceTask.Queries.GetMaintenanceTaskQuery;

public record GetMaintenanceTaskQueryHandler(IAircraftMaintenanceDbContext DbContext) : IQueryHandler<GetMaintenanceTaskQuery, GetMaintenanceTaskQueryResult>
{
    public async Task<GetMaintenanceTaskQueryResult> Handle(GetMaintenanceTaskQuery query, CancellationToken cancellationToken)
    {
        // Fetch from two different sources
        var mRequest = DbContext.MaintenanceRequests.OrderBy(mr => mr.RequestNumber).AsNoTracking();
        var wOrder = DbContext.WorkOrders.OrderBy(wo => wo.Id).AsNoTracking();

        //map sources
        var requestTasks = await mRequest.Select(r => new MaintenanceTaskDto(
            MaintenanceTaskType.MR,
            r.RequestNumber,
            r.Title,
            r.MaintenancePriority,
            r.MaintenanceRequestStatus.ToString(),
            r.DueDate,
            null,
            new AircraftSummaryDto(
                r.Aircraft.Id,
                r.Aircraft.TailNumber,
                r.Aircraft.Manufacturer,
                r.Aircraft.Year,
                r.Aircraft.SerialNumber,
                r.Aircraft.Model,
                r.Aircraft.FlightHours,
                r.Aircraft.LastMaintenanceDate,
                r.Aircraft.NextMaintenanceDate))).ToListAsync(cancellationToken);

        var orderTasks = await wOrder.Select(o => new MaintenanceTaskDto(
            MaintenanceTaskType.WO,
            o.WorkOrderNumber,
            o.Title,
            o.WorkOrderPriority,
            o.WorkOrderStatus.ToString(),
            o.EstimatedCompletionDate,    
            o.AssignedTechnicianId,
            new AircraftSummaryDto(
                o.Aircraft.Id,
                o.Aircraft.TailNumber,
                o.Aircraft.Manufacturer,
                o.Aircraft.Year,
                o.Aircraft.SerialNumber,
                o.Aircraft.Model,
                o.Aircraft.FlightHours,
                o.Aircraft.LastMaintenanceDate,
                o.Aircraft.NextMaintenanceDate))).ToListAsync(cancellationToken); 

        //combine the sources into a collection of DTOs
        var maintenanceTasks = requestTasks.Concat(orderTasks);
        return new GetMaintenanceTaskQueryResult(maintenanceTasks);    
    }
}
