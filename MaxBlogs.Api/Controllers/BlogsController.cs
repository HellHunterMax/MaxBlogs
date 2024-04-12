using MaxBlogs.Application.Managers.Interfaces;
using MaxBlogs.Contracts.Blogs;
using Microsoft.AspNetCore.Mvc;

namespace MaxBlogs.Api.Controllers;

[ApiController]
[Route("[Controller]")]
public class BlogsController : ControllerBase
{
    private readonly ILogger<BlogsController> _logger;
    private readonly IBlogsManager _blogsManager;

    public BlogsController(ILogger<BlogsController> logger, IBlogsManager blogsManager)
    {
        _logger = logger;
        _blogsManager = blogsManager;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBlogAsync(CreateBlogRequest request)
    {
        _logger.LogInformation("Recieved request to create a blog {request}", request);

        var result = await _blogsManager.CreateBlogAsync(request.UserId, request.Title, request.Text);
        if (result.IsFailed)
        {
            return BadRequest(result.Errors.FirstOrDefault()?.Message);
        }

        var response = new CreateBlogResponse(result.Value);

        return Ok(response);
    }
}
