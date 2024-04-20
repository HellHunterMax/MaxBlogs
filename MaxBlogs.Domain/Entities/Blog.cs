using Common.FluentResults.Errors;
using FluentResults;
using MaxBlogs.Domain.Entities.Base;

namespace MaxBlogs.Domain.Entities;
public class Blog : Entity
{
    public string Title { get; set; }
    public string Text { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Blog() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public Blog(string title, string text) : base()
    {
        Title = !string.IsNullOrEmpty(title) ? title : throw new ArgumentNullException(title, $"Blog: {nameof(Title)} should not be null or empty");
        Text = !string.IsNullOrEmpty(text) ? text : throw new ArgumentNullException(text, $"Blog: {nameof(Text)} should not be null or empty");
    }

    public static Result<Blog> Create(string title, string text)
    {
        if (string.IsNullOrEmpty(title))
        {
            return ValidationError.CannotBeNull<string>(nameof(title));
        }

        if (string.IsNullOrEmpty(text))
        {
            return ValidationError.CannotBeNull<string>(nameof(text));
        }

        return new Blog(title, text);
    }
}
