using FluentValidation;
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

        services.AddValidatorsFromAssemblyContaining(typeof(ModuleExtensions));

        return services;
    }
}
