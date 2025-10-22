using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace VB.HotChocoBoard.Application.Abstract.FluentValidation;

public sealed class ValidationEnvelope<TRequest, TResponse>(IValidator<TRequest>? validator)
    where TRequest : IRequest<TResponse>
{
    private ValidationResult? _result;

    public bool HasRules() => validator != null;

    public void Validate(TRequest request) => _result = validator?.Validate(request);

    public bool HasFailures() => _result != null && _result.Errors.Count != 0;

    public IEnumerable<ValidationFailure> GetFailures() => _result?.Errors ?? [];
}