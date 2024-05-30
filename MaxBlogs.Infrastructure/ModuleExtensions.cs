using MaxBlogs.Application.Common.Interfaces;
using MaxBlogs.Infrastructure.Blogs.Persistance;
using MaxBlogs.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MaxBlogs.Infrastructure;

public static class ModuleExtensions
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<BlogsDBContext>(options =>
        options.UseSqlite("Data Source = MaxBlogs.db"));

        services.AddScoped<IBlogsRepository, BlogsRepository>();
        return services;
    }
}
