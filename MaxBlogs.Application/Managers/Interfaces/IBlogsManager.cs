using FluentResults;

namespace MaxBlogs.Application.Managers.Interfaces;

public interface IBlogsManager
{
    internal Task<Result<Guid>> CreateBlogAsync(Guid userId, string title, string text);
}
