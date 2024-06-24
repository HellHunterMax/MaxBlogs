using Common.FluentResults.Errors;
using FluentResults;
using MaxBlogs.Domain.Entities.Base;

namespace MaxBlogs.Domain.Blogs;
public class Blog : Entity
{
    public string Title { get; private set; }
    public string Text { get; private set; }
    public List<Guid> AuthorIds { get; private set; } = [];
    public List<Guid> BlogEntryIds { get; private set; } = [];

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Blog() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public Blog(string title, string text) : base()
    {
        Title = !string.IsNullOrEmpty(title) ? title : throw new ArgumentNullException(title, $"Blog: {nameof(Title)} should not be null or empty");
        Text = !string.IsNullOrEmpty(text) ? text : throw new ArgumentNullException(text, $"Blog: {nameof(Text)} should not be null or empty");
    }

    public static Result<Blog> Create(Guid authorId, string title, string text)
    {
        if (string.IsNullOrEmpty(title))
        {
            return ValidationError.CannotBeNull<string>(nameof(title));
        }

        if (string.IsNullOrEmpty(text))
        {
            return ValidationError.CannotBeNull<string>(nameof(text));
        }

        var blog = new Blog(title, text);

        blog.AddBlogAuthor(authorId);

        return blog;
    }

    public Result AddBlogAuthor(Guid authorId)
    {
        if (AuthorIds.Contains(authorId))
        {
            return Result.Ok();
        }

        AuthorIds.Add(authorId);
        return Result.Ok();
    }

    public Result AddBlogEntry(Guid blogEntryId)
    {
        if (BlogEntryIds.Contains(blogEntryId))
        {
            return Result.Ok();
        }

        BlogEntryIds.Add(blogEntryId);
        return Result.Ok();
    }

    public Result RemoveBlogEntry(Guid blogEntryId)
    {
        if (!BlogEntryIds.Contains(blogEntryId))
        {
            return Result.Ok();
        }

        BlogEntryIds.Remove(blogEntryId);
        return Result.Ok();
    }
}
