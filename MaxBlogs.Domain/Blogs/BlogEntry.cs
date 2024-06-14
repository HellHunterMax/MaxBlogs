using MaxBlogs.Domain.Entities.Base;

namespace MaxBlogs.Domain.Blogs;
public class BlogEntry : Entity
{
    public required string Title { get; set; }
    public required string Text { get; set; }
}
