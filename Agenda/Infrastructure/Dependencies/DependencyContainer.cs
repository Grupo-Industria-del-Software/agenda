using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Dependencies;

public static class DependencyContainer
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services;
    }
}