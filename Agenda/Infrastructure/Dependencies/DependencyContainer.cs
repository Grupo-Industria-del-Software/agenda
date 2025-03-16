using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.Types;
using Application.Services;
using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Dependencies;

public static class DependencyContainer
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Type
        services.AddScoped<ITypeService, TypeService>();
        services.AddScoped<ITypeRepository, TypeRepository>();

        return services;
    }
}