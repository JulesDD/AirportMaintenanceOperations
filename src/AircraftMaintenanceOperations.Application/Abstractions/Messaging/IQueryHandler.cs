namespace AircraftMaintenanceOperations.Application.Abstractions.Messaging;

internal interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
    where TResponse : notnull
{
}
