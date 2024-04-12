using MaxBlogs.Api.Controllers;
using MaxBlogs.Api.UnitTests.Attributes;
using MaxBlogs.Contracts.Blogs;
using Microsoft.AspNetCore.Mvc;

namespace MaxBlogs.Api.UnitTests.Controllers;

public class BlogsControllerTests
{
    [Theory, ControllerAutoMoqInlineDataAttribute]
    public async Task CreateBlogRequest_ValidRequest_OkGuild(
        BlogsController sut,
        CreateBlogRequest request)
    {
        var expected = new OkObjectResult(request);

        var result = await sut.CreateBlogAsync(request);

        result.Should().BeEquivalentTo(expected);
    }
}
