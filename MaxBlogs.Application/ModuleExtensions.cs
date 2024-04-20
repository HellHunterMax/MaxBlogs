using Microsoft.Extensions.DependencyInjection;

namespace MaxBlogs.Application;

public static class ModuleExtensions
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblyContaining(typeof(ModuleExtensions));
        });

        return services;
    }
}
