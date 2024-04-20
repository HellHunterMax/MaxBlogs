using MaxBlogs.Application.Common.Interfaces;
using MaxBlogs.Domain.Entities;

namespace MaxBlogs.Infrastructure.Blogs.Persistance;
public class BlogsRepository : IBlogsRepository
{
    private readonly List<Blog> _blogs =
    [
        new Blog(new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), "Initial", "This is some text for the initial blog. More might be added later.")
    ];

    public Task AddBlogAsync(Blog blog)
    {
        _blogs.Add(blog);

        return Task.CompletedTask;
    }

    public Task<Blog?> GetBlogByIdAsync(Guid id)
    {
        return Task.Run(() => _blogs.FirstOrDefault(x => x.Id == id));
    }

    public Task<IEnumerable<Blog>> GetForAuthorAsync(Guid authorId)
    {
        return Task.Run(() => _blogs.Where(x => x.AuthorId == authorId));
    }
}
