using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TemplateAPI.Application.Services;
using TemplateAPI.Application.Services.Interfaces;

namespace TemplateAPI.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<TokenService>();
        services.AddTransient<IUserCreatorService, UserCreatorService>();
        services.AddTransient<IUserUpdaterService, UserUpdaterService>();
        services.AddTransient<IUserDeleterService, UserDeleterService>();
        services.AddTransient<IUserSearcherService, UserSearcherService>();
        services.AddTransient<IUserFinderService, UserFinderService>();
        return services;
    }
}