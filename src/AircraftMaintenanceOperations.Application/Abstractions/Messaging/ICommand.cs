namespace AircraftMaintenanceOperations.Application.Abstractions.Messaging;

public interface ICommand : ICommand<Unit>
{
}

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
