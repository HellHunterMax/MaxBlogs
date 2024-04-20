using FluentResults;
using MaxBlogs.Application.Common.Interfaces;
using MaxBlogs.Domain.Entities;
using MediatR;

namespace MaxBlogs.Application.CQRS.Blogs.Commands.Create;
internal class CreateBlogHandler : IRequestHandler<CreateBlog, Result<Blog>>
{
    private readonly IBlogsRepository _blogsRepository;
    //private readonly IUnitOfWork _unitOfWork;

    public CreateBlogHandler(IBlogsRepository blogsRepository)
    {
        _blogsRepository = blogsRepository;
        //_unitOfWork = unitOfWork;
    }

    public async Task<Result<Blog>> Handle(CreateBlog request, CancellationToken cancellationToken)
    {
        var blogResult = Blog.Create(request.UserId, request.Title, request.Text);

        if (blogResult.IsFailed)
        {
            return blogResult;
        }

        await _blogsRepository.AddBlogAsync(blogResult.Value);
        //await _unitOfWork.CommitChangesAsync();

        return blogResult;
    }
}
