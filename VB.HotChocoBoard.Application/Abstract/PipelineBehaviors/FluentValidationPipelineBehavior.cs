using FluentValidation;
using MediatR;
using VB.HotChocoBoard.Application.Abstract.FluentValidation;

namespace VB.HotChocoBoard.Application.Abstract.PipelineBehaviors;

public sealed class FluentValidationPipelineBehavior<TRequest, TResponse>(
    IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ValidationEnvelope<TRequest, TResponse> _envelope = new(validators.FirstOrDefault());

    public Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!_envelope.HasRules())
            return next(cancellationToken);

        _envelope.Validate(request);

        return _envelope.HasFailures() 
            ? throw new ValidationException(_envelope.GetFailures()) 
            : next(cancellationToken);
    }
}