namespace MaxBlogs.Contracts.Blogs;

public record DeleteBlogRequest(Guid UserId, Guid BlogId)
{
}

