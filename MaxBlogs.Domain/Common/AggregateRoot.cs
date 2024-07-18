
namespace MaxBlogs.Domain.Common;

public class AggregateRoot : Entity
{
    public AggregateRoot() : base() { }

    public AggregateRoot(Guid? id) : base(id ?? Guid.NewGuid())
    {
    }
}
