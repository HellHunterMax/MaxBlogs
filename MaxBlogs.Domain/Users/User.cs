namespace MaxBlogs.Domain.Users;

public class User
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }

    //TODO different User management.
    /// <summary>
    /// Plain text for now
    /// </summary>
    public required string Password { get; set; }
}
