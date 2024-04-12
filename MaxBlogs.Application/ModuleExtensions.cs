using MaxBlogs.Application.Managers;
using MaxBlogs.Application.Managers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MaxBlogs.Application;

public static class ModuleExtensions
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IBlogsManager, BlogsManager>();
        return services;
    }
}
