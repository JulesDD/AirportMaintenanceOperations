namespace AircraftMaintenanceOperations.Application.Abstractions.Messaging;

public interface IQuery<out TResponse> : IRequest<TResponse>
    where TResponse : notnull
{
}