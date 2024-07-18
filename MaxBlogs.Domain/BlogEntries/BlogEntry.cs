using MaxBlogs.Domain.Common;

namespace MaxBlogs.Domain.BlogEntries;

public class BlogEntry : AggregateRoot
{
    public string Title { get; private set; }
    public string Text { get; private set; }
    public Guid AuthorId { get; private set; }
    public Guid BlogId { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public BlogEntry() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public BlogEntry(string title, string text, Guid authorId, Guid blogId, Guid? id = null) : base(id ?? Guid.NewGuid())
    {
        Title = title;
        Text = text;
        AuthorId = authorId;
        BlogId = blogId;
    }
}
