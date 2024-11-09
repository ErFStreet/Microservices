namespace Microservice.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior
    <TRequest, TResponse> where TRequest : class
{
    private readonly IEnumerable<IValidator> _validators;

    public ValidationBehavior(IEnumerable<IValidator> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var validationResults = 
            await Task.WhenAll(
                _validators
                .Select(v => v.ValidateAsync(context, cancellationToken)));

        var failures = validationResults
            .Where(r => r.Errors.Count > 0)
            .SelectMany(r => r.Errors)
            .ToList();

        if (failures.Count > 0)
            throw new FluentValidation.ValidationException(failures);

        return await next();
    }
}