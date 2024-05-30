using MaxBlogs.Application.Common.Interfaces;
using MaxBlogs.Domain.Entities;
using MaxBlogs.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MaxBlogs.Infrastructure.Blogs.Persistance;
internal class BlogsRepository : IBlogsRepository
{
    private readonly BlogsDBContext _context;

    public BlogsRepository(BlogsDBContext context)
    {
        _context = context;
    }

    public async Task AddBlogAsync(Blog blog)
    {
        await _context.Blogs.AddAsync(blog);
        await _context.SaveChangesAsync();
    }

    public async Task<Blog?> GetBlogByIdAsync(Guid id)
    {
        return await _context.Blogs.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Blog>> GetForAuthorAsync(Guid authorId)
    {
        return await _context.Blogs.Where(x => x.AuthorId == authorId).ToListAsync();
    }
}
