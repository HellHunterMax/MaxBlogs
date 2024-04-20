using MaxBlogs.Application.Common.Interfaces;
using MaxBlogs.Infrastructure.Blogs.Persistance;
using Microsoft.Extensions.DependencyInjection;

namespace MaxBlogs.Infrastructure;

public static class ModuleExtensions
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<IBlogsRepository, BlogsRepository>();
        return services;
    }
}
