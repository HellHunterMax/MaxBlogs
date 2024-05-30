using MaxBlogs.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MaxBlogs.Infrastructure.Common.Persistence;
internal class BlogsDBContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }

    public BlogsDBContext(DbContextOptions options) : base(options)
    {

    }
}
