namespace SibGAU.Blogs.Domain;

/// <summary>
/// Tag.
/// </summary>
public class Tag
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
    /// Blogs.
    /// </summary>
    public ICollection<Blog> Blogs = new List<Blog>();
}