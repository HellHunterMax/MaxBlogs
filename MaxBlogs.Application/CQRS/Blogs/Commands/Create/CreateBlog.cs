using FluentResults;
using MaxBlogs.Domain.Entities;
using MediatR;

namespace MaxBlogs.Application.CQRS.Blogs.Commands.Create;
public record CreateBlog(Guid UserId, string Title, string Text) : IRequest<Result<Blog>>;
