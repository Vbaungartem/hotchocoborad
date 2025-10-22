using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VB.HotChocoBoard.Infrastructure.Data;

namespace VB.HotChocoBoard.Infrastructure.IoC;

public static class DbContextInjection
{
    public static IServiceCollection ConfigureDbContextInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BoardDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlServer")));

        return services;
    }
}