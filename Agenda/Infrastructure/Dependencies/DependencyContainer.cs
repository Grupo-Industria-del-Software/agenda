using Application.Interfaces.Auth;
using Application.Interfaces.Jwt;
using Application.Interfaces.Utils;
using Application.Services.Auth;
using Application.Services.Utils;
using Infrastructure.Repositories;
using Infrastructure.Services.Jwt;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Dependencies;

public static class DependencyContainer
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        
        // Auth
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IAuthRepository, AuthRepository>();
        
        // Utils
        services.AddSingleton<IPasswordHasher, PasswordHasher>();
        services.AddSingleton<IJwtService, JwtService>();
        
        return services;
    }
}