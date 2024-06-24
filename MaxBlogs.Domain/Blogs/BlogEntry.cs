using MaxBlogs.Domain.Entities.Base;
using MaxBlogs.Domain.Users;

namespace MaxBlogs.Domain.Blogs;
public class BlogEntry : Entity
{
    public string Title { get; private set; }
    public string Text { get; private set; }
    public User User { get; private set; }
    public Blog Blog { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public BlogEntry() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
