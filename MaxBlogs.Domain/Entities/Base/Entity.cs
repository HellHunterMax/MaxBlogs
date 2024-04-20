namespace MaxBlogs.Domain.Entities.Base;
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
}
