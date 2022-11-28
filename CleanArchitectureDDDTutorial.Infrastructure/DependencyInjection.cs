using CleanArchitectureDDDTutorial.Application.Common.Interfaces.Authentication;
using CleanArchitectureDDDTutorial.Application.Common.Interfaces.Services;
using CleanArchitectureDDDTutorial.Infrastructure.Authentication;
using CleanArchitectureDDDTutorial.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureDDDTutorial.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
}
