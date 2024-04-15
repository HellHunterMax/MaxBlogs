using Microsoft.Extensions.DependencyInjection;

namespace MaxBlogs.Infrastructure;

public static class ModuleExtensions
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
    {
        return services;
    }
}
