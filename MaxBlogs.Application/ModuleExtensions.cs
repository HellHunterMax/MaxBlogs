using FluentValidation;
using MaxBlogs.Application.Common.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace MaxBlogs.Application;

public static class ModuleExtensions
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblyContaining(typeof(ModuleExtensions));

            options.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssemblyContaining(typeof(ModuleExtensions));

        return services;
    }
}
