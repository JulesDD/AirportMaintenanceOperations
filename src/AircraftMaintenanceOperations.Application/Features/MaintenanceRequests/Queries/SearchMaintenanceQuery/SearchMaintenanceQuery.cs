namespace AircraftMaintenanceOperations.Application.Features.MaintenanceRequests.Queries.SearchMaintenanceQuery;

public record SearchMaintenanceQuery(string RequestNumber, string RequestedBy) : IQuery<SearchMaintenanceResult>;
public record SearchMaintenanceResult(IEnumerable<MaintenanceRequestDto> MaintenanceRequests);
