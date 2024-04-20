using Common.FluentResults.Errors;
using FluentResults;
using MaxBlogs.Application.Common.Interfaces;
using MaxBlogs.Domain.Entities;
using MediatR;

namespace MaxBlogs.Application.CQRS.Blogs.Queries.GetById;
internal class GetBlogByIdHandler : IRequestHandler<GetBlogById, Result<Blog>>
{

    private readonly IBlogsRepository _blogsRepository;

    public GetBlogByIdHandler(IBlogsRepository blogsRepository)
    {
        _blogsRepository = blogsRepository;
    }

    public async Task<Result<Blog>> Handle(GetBlogById request, CancellationToken cancellationToken)
    {
        var result = await _blogsRepository.GetBlogByIdAsync(request.Id);
        if (result == null)
        {
            return NotFoundError.NotFound<Blog>(nameof(Blog.Id), request.Id.ToString());
        }

        return result;
    }
}
