using MaxBlogs.Domain.Blogs;
using MaxBlogs.Domain.Common;

namespace MaxBlogs.Domain.Users;

public class User : Entity
{
    public string Name { get; private set; }
    public string Email { get; private set; }

    //TODO different User management.
    /// <summary>
    /// Plain text for now
    /// </summary>
    public string Password { get; private set; }
    public List<Blog> Blogs { get; private set; } = [];

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public User() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public User(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }
}
