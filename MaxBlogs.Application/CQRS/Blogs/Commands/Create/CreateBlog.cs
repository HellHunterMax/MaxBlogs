using FluentResults;
using MediatR;

namespace MaxBlogs.Application.CQRS.Blogs.Commands.Create;
public record CreateBlog(Guid UserId, string Title, string Text) : IRequest<Result<Guid>>;
