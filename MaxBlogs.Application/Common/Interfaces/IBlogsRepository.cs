using MaxBlogs.Domain.Entities;

namespace MaxBlogs.Application.Common.Interfaces;

public interface IBlogsRepository
{
    Task AddBlogAsync(Blog blog);
    Task<Blog?> GetBlogByIdAsync(Guid id);
    Task<IEnumerable<Blog>> GetForAuthorAsync(Guid authorId);
}
