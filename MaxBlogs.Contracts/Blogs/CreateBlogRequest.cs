namespace MaxBlogs.Contracts.Blogs;

public record CreateBlogRequest(Guid UserId, string Title, string Text) { }
