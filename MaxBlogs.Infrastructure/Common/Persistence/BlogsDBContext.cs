using MaxBlogs.Application.Common.Interfaces;
using MaxBlogs.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MaxBlogs.Infrastructure.Common.Persistence;
internal class BlogsDBContext : DbContext, IUnitOfWork
{
    public DbSet<Blog> Blogs { get; set; }

    public BlogsDBContext(DbContextOptions options) : base(options)
    {

    }

    public async Task CommitChangesAsync()
    {
        await base.SaveChangesAsync();
    }
}
