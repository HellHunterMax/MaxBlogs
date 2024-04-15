using AutoFixture.Xunit2;
using MaxBlogs.Api.Controllers;
using MaxBlogs.Api.UnitTests.Attributes;
using MaxBlogs.Application.CQRS.Blogs.Commands.Create;
using MaxBlogs.Contracts.Blogs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace MaxBlogs.Api.UnitTests.Controllers;

public class BlogsControllerTests
{
    [Theory, ControllerAutoMoqInlineDataAttribute]
    public async Task CreateBlogRequest_ValidRequest_OkGuild(
        [Frozen] Mock<ISender> _mediatorMock,
        CreateBlog createBlogRequest,
        BlogsController sut,
        CreateBlogRequest request,
        CreateBlogResponse expected)
    {
        _mediatorMock.Setup(x => x.Send(createBlogRequest, CancellationToken.None)).ReturnsAsync(expected.Id);

        var result = await sut.CreateBlogAsync(request, CancellationToken.None);

        result.Should().BeEquivalentTo(new OkObjectResult(expected));
    }
}
