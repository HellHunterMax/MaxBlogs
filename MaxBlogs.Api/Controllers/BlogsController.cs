using MaxBlogs.Contracts.Blogs;
using Microsoft.AspNetCore.Mvc;

namespace MaxBlogs.Api.Controllers;

[ApiController]
[Route("[Controller]")]
public class BlogsController : ControllerBase
{
    private readonly ILogger<BlogsController> _logger;

    public BlogsController(ILogger<BlogsController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBlogAsync(CreateBlogRequest request)
    {
        _logger.LogInformation("Recieved request to create a blog {request}", request);

        await Task.Delay(100);
        return Ok(request);
    }
}
