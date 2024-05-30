using FluentResults;
using MediatR;

namespace MaxBlogs.Application.CQRS.Blogs.Commands.Delete;
public record DeleteBlog(Guid Id, Guid UserId) : IRequest<Result>;
