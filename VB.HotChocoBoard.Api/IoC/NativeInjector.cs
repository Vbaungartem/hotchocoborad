using VB.BookStore.Api.Extensions;
using VB.HotChocoBoard.Application.Abstract.IoC;
using VB.HotChocoBoard.Infrastructure.IoC;

namespace VB.BookStore.Api.IoC;

public static class NativeInjector
{
    public static void ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .ConfigureDbContextInjection(configuration)
            .ConfigureMediator()
            .ConfigureFluentValidation()
            .ConfigureGraphQl();
    }
}