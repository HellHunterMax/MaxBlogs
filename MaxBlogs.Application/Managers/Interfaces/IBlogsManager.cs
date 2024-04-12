using FluentResults;

namespace MaxBlogs.Application.Managers.Interfaces;

public interface IBlogsManager
{
    Task<Result<Guid>> CreateBlogAsync(Guid userId, string title, string text);
}
