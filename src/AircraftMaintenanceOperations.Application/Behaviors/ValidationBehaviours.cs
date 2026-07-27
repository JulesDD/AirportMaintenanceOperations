namespace AircraftMaintenanceOperations.Application.Behaviors;

public class ValidationBehaviours<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommand<TResponse>
{
    //The pipeline interception point
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        //Execute all validatiors
        var validationResults = await Task.WhenAll(validators.Select(x => x.ValidateAsync(context, cancellationToken)));

        // Collect Errors
        var failures = validationResults
            .Where(r => r.Errors.Any())
            .SelectMany(r => r.Errors)
            .ToList();

        // Throws an exception should the validation fails
        if (failures.Any())
        {
            throw new ValidationException(failures);
        }

        //Runs to handler
        return await next();
    }
}
