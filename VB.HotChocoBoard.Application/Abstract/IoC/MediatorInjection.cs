using Microsoft.Extensions.DependencyInjection;

namespace VB.HotChocoBoard.Application.Abstract.IoC;

public static class MediatorInjection
{
    public static IServiceCollection ConfigureMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(MediatorInjection).Assembly));
        return services;
    }
}