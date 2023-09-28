namespace SibGAU.Blogs.Domain;

/// <summary>
/// Rubric.
/// </summary>
public class Rubric
{
    /// <summary>
    /// Id.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Name.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Blogs.
    /// </summary>
    public ICollection<Blog>? Blogs { get; set; } = new List<Blog>();
}