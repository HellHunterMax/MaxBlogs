using Common.FluentResults.Errors;
using MaxBlogs.Application.CQRS.Blogs.Commands.Create;
using MaxBlogs.Application.CQRS.Blogs.Queries.GetById;
using MaxBlogs.Contracts.Blogs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MaxBlogs.Api.Controllers;

[ApiController]
[Route("[Controller]")]
public class BlogsController : ControllerBase
{
    private readonly ILogger<BlogsController> _logger;
    private readonly ISender _mediator;

    public BlogsController(ILogger<BlogsController> logger, ISender mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBlogAsync(CreateBlogRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Recieved request to create a blog {request}", request);

        var createBlogRequest = new CreateBlog(request.UserId, request.Title, request.Text);

        var result = await _mediator.Send(createBlogRequest, cancellationToken);
        if (result.IsFailed)
        {
            return BadRequest(result.Errors.FirstOrDefault()?.Message);
        }

        var response = new CreateBlogResponse(result.Value.Id);

        return Ok(response);
    }

    [HttpGet("{blogId:guid}")]
    public async Task<IActionResult> CreateBlogAsync(Guid blogId, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Recieved request to Get a blog {blogId}", blogId);

        var blogRequest = new GetBlogById(blogId);

        var result = await _mediator.Send(blogRequest, cancellationToken);
        if (result.IsFailed)
        {
            if (result.HasError<NotFoundError>())
            {
                return new NotFoundObjectResult(result.Errors);
            }

            if (result.HasError<ValidationError>())
            {
                return BadRequest(result.Errors);
            }

            return BadRequest(result.Errors);
        }

        return Ok(result.Value);
    }
}
