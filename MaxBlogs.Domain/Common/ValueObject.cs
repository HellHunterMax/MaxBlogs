namespace MaxBlogs.Domain.Common;

public abstract class ValueObject
{
    public abstract IEnumerable<object> GetEquallityComponents();

    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
        {
            return false;
        }

        return ((ValueObject)obj).GetEquallityComponents().SequenceEqual(GetEquallityComponents());

    }

    public override int GetHashCode()
    {
        return GetEquallityComponents()
            .Select(x => x?.GetHashCode() ?? 0)
            .Aggregate((x, y) => x ^ y);
    }
}
