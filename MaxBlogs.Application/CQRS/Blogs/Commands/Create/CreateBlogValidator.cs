using FluentValidation;

namespace MaxBlogs.Application.CQRS.Blogs.Commands.Create;

public class CreateBlogValidator : AbstractValidator<CreateBlog>
{
    public CreateBlogValidator()
    {
        RuleFor(x => x.Text).NotEmpty().WithMessage("text cannot be null or empty");
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title cannot be null or empty");
    }
}
