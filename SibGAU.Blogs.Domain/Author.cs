using Microsoft.AspNetCore.Identity;

namespace SibGAU.Blogs.Domain;

/// <summary>
/// Author.
/// </summary>
public class Author : IdentityUser
{
    /// <summary>
    /// Blogs.
    /// </summary>
    public ICollection<Blog> Blogs { get; set; } = new List<Blog>();
}