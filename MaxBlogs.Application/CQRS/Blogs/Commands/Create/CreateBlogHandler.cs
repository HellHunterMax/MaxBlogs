using FluentResults;
using MaxBlogs.Application.Managers.Interfaces;
using MediatR;

namespace MaxBlogs.Application.CQRS.Blogs.Commands.Create;
internal class CreateBlogHandler : IRequestHandler<CreateBlog, Result<Guid>>
{
    private readonly IBlogsManager _blogsManager;

    public CreateBlogHandler(IBlogsManager blogsManager)
    {
        _blogsManager = blogsManager;
    }

    public async Task<Result<Guid>> Handle(CreateBlog request, CancellationToken cancellationToken)
    {
        return await _blogsManager.CreateBlogAsync(request.UserId, request.Title, request.Text);
    }
}
