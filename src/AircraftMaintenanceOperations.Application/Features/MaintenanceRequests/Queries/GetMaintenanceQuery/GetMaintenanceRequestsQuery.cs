namespace AircraftMaintenanceOperations.Application.Features.MaintenanceRequests.Queries.GetMaintenanceQuery;

public record GetMaintenanceRequestsQuery(
    string? RequestedBy,
    MaintenanceRequestStatus? Status,
    MaintenancePriority? Priority) : IQuery<GetMaintenanceResult>;
public record GetMaintenanceResult(IEnumerable<MaintenanceRequestDto> MaintenanceRequests);
