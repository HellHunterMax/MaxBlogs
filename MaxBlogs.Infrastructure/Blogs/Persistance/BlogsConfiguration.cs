using MaxBlogs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaxBlogs.Infrastructure.Blogs.Persistance;

internal class BlogsConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id).ValueGeneratedNever();
    }
}
