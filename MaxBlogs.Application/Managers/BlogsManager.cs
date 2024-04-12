using FluentResults;
using MaxBlogs.Application.Managers.Interfaces;

namespace MaxBlogs.Application.Managers;

internal class BlogsManager : IBlogsManager
{
    public async Task<Result<Guid>> CreateBlogAsync(Guid userId, string title, string text)
    {
        await Task.Delay(1000);

        return Guid.NewGuid();
    }
}
