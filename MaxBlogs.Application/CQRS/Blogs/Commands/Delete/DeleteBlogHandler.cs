using Common.FluentResults.Errors;
using FluentResults;
using MaxBlogs.Application.Common.Interfaces;
using MaxBlogs.Domain.Entities;
using MediatR;

namespace MaxBlogs.Application.CQRS.Blogs.Commands.Delete;

public record DeleteBlogHandler : IRequestHandler<DeleteBlog, Result>
{
    private readonly IBlogsRepository _blogsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBlogHandler(IBlogsRepository blogsRepository, IUnitOfWork unitOfWork)
    {
        _blogsRepository = blogsRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteBlog request, CancellationToken cancellationToken)
    {
        var blog = await _blogsRepository.GetBlogByIdAsync(request.Id);

        if (blog == null)
        {
            return NotFoundError.NotFound<Blog>(request.Id.ToString(), nameof(blog.Id));
        }

        if (blog.AuthorId != request.UserId)
        {
            return NotAllowedError.NotAllowed(request.UserId, $"Delete blog '{blog.Id}' who its not owner of.");
        }

        await _blogsRepository.DeleteAsync(blog);
        await _unitOfWork.CommitChangesAsync();

        return Result.Ok();
    }
}
