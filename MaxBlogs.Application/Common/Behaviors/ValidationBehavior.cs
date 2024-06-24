using Common.FluentResults.Errors;
using FluentResults;
using FluentValidation;
using MediatR;

namespace MaxBlogs.Application.Common.Behaviors;

internal class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : ResultBase
{
    private readonly IValidator<TRequest> _validator;

    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validator == null)
        {
            return await next();
        }

        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid)
        {
            await next();
        }

        return (dynamic)Result.Fail(validationResult.Errors.Select(e => new ValidationError(e.ErrorMessage)).ToList());
    }
}
