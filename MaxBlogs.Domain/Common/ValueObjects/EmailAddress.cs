namespace MaxBlogs.Domain.Common.ValueObjects;

internal class EmailAddress : ValueObject
{
    public required string Value { get; init; }

    public override IEnumerable<object> GetEquallityComponents()
    {
        yield return Value;
    }
}
