using Common.FluentResults.Errors;

namespace MaxBlogs.Domain.Blogs.Errors;

public static class BlogErrors
{
    public static UnexpectedError AuthorAlreadyBlogAuthorError(Guid userId, Guid blogId)
    {
        return UnexpectedError.UnexpectedAction($"Author '{userId}' is already an Author for Blog '{blogId}' and cannot be added again.");
    }
}
