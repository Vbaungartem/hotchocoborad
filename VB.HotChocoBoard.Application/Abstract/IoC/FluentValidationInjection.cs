using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using VB.HotChocoBoard.Application.Abstract.PipelineBehaviors;

namespace VB.HotChocoBoard.Application.Abstract.IoC;

public static class FluentValidationInjection
{
    public static IServiceCollection ConfigureFluentValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(FluentValidationInjection).Assembly);
        
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationPipelineBehavior<,>));
        
        return services;
    }
}