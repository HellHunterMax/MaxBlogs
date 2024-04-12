using AutoFixture.Xunit2;
using MaxBlogs.Api.Controllers;
using MaxBlogs.Api.UnitTests.Attributes;
using MaxBlogs.Application.Managers.Interfaces;
using MaxBlogs.Contracts.Blogs;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace MaxBlogs.Api.UnitTests.Controllers;

public class BlogsControllerTests
{
    [Theory, ControllerAutoMoqInlineDataAttribute]
    public async Task CreateBlogRequest_ValidRequest_OkGuild(
        [Frozen] Mock<IBlogsManager> blogsManagerMock,
        BlogsController sut,
        CreateBlogRequest request,
        CreateBlogResponse expected)
    {
        blogsManagerMock.Setup(x => x.CreateBlogAsync(request.UserId, request.Title, request.Text)).ReturnsAsync(expected.Id);

        var result = await sut.CreateBlogAsync(request);

        result.Should().BeEquivalentTo(new OkObjectResult(expected));
    }
}
