using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.Types;
using Application.Services;
using Domain.Entities;
using Infrastructure.Repositories;

using Application.Interfaces.Auth;
using Application.Interfaces.Jwt;
using Application.Interfaces.Utils;
using Application.Interfaces.Activities;
using Application.Services.Activities;
using Application.Services.Auth;
using Application.Services.Utils;
using Infrastructure.Services.Jwt;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Dependencies;

public static class DependencyContainer
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Type
        services.AddScoped<ITypeService, TypeService>();
        services.AddScoped<ITypeRepository, TypeRepository>();
        
        // Auth
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IAuthRepository, AuthRepository>();
        
        // Utils
        services.AddSingleton<IPasswordHasher, PasswordHasher>();
        services.AddSingleton<IJwtService, JwtService>();

        // Activity
        services.AddScoped<IActivityService, ActivityService>();
        services.AddScoped<IActivityRepository, ActivityRepository>();

        return services;
    }
}