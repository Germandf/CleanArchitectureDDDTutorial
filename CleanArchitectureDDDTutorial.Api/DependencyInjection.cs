using CleanArchitectureDDDTutorial.Api.Common.Errors;
using CleanArchitectureDDDTutorial.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CleanArchitectureDDDTutorial.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddMappings();
        return services;
    }
}
