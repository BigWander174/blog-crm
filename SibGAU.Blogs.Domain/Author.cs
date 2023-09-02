namespace SibGAU.Blogs.Domain;

/// <summary>
/// Author.
/// </summary>
public class Author
{
    /// <summary>
    /// Id.
    /// </summary>
    public int Id { get; private set; }
    
    /// <summary>
    /// Name.
    /// </summary>
    public required string Name { get; set; }
    
    /// <summary>
    /// Email.
    /// </summary>
    public required string Email { get; set; }
    
    /// <summary>
    /// Phone.
    /// </summary>
    public long Phone { get; set; }

    /// <summary>
    /// Blogs.
    /// </summary>
    public ICollection<Blog> Blogs { get; set; } = new List<Blog>();
}