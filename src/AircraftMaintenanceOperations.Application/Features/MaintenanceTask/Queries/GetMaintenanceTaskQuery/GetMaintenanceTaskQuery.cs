namespace AircraftMaintenanceOperations.Application.Features.MaintenanceTask.Queries.GetMaintenanceTaskQuery;

public record GetMaintenanceTaskQuery(
    MaintenanceTaskType? Type,
    Guid? TechnicianId,
    MaintenancePriority? Priority,
    string? Status) : IQuery<GetMaintenanceTaskQueryResult>;
public record GetMaintenanceTaskQueryResult(IEnumerable<MaintenanceTaskDto> MaintenanceTasks);