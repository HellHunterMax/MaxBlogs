using FluentResults;
using MaxBlogs.Domain.Entities;
using MediatR;

namespace MaxBlogs.Application.CQRS.Blogs.Queries.GetById;

public record GetBlogById(Guid Id) : IRequest<Result<Blog>>
{

}
