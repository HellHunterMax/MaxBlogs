namespace MaxBlogs.Domain.Common;
public class Entity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Entity()
    {
    }

    public Entity(Guid id)
    {
        Id = id;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType())
        {
            return false;
        }

        return ((Entity)obj).Id == Id;
    }
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
