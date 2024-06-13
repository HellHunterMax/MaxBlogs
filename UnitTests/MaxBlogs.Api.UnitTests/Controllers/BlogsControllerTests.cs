using AutoFixture.Xunit2;
using MaxBlogs.Api.Controllers;
using MaxBlogs.Api.UnitTests.Attributes;
using MaxBlogs.Application.CQRS.Blogs.Commands.Create;
using MaxBlogs.Contracts.Blogs;
using MaxBlogs.Domain.Blogs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace MaxBlogs.Api.UnitTests.Controllers;

public class BlogsControllerTests
{
    //This test, tests nothing >_<
    [Theory, ControllerAutoMoqInlineDataAttribute]
    public async Task CreateBlogRequest_ValidRequest_OkGuild(
        [Frozen] Mock<ISender> _mediatorMock,
        BlogsController sut,
        CreateBlogRequest request,
        Blog blog,
        CancellationToken cancellationToken)
    {
        _mediatorMock.Setup(x => x.Send(It.Is<CreateBlog>(x => x.UserId == request.UserId && x.Title == request.Title && x.Text == request.Text), cancellationToken)).ReturnsAsync(blog);

        var result = await sut.CreateBlogAsync(request, cancellationToken);

        result.Should().BeEquivalentTo(new OkObjectResult(new CreateBlogResponse(blog.Id)));
    }
}
