namespace SibGAU.Blogs.Domain;

/// <summary>
/// Blog.
/// </summary>
public class Blog
{
    /// <summary>
    /// Id.
    /// </summary>
    public int Id { get; private set; }
    
    /// <summary>
    /// Title.
    /// </summary>
    public required string Title { get; set; }
    
    /// <summary>
    /// Content.
    /// </summary>
    public required string Content { get; set; }
    
    /// <summary>
    /// Author id.
    /// </summary>
    public required string AuthorId { get; init; }

    /// <summary>
    /// Author.
    /// </summary>
    public Author Author { get; init; } = null!;
    
    /// <summary>
    /// Rubric id.
    /// </summary>
    public int? RubricId { get; set; }

    /// <summary>
    /// Rubric.
    /// </summary>
    public Rubric? Rubric { get; set; }

    /// <summary>
    /// Tags.
    /// </summary>
    public ICollection<Tag> Tags { get; set; } = new List<Tag>();

    /// <summary>
    /// Created at.
    /// </summary>
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    /// <summary>
    /// Edited at.
    /// </summary>
    public DateTime EditedAt { get; set; } = DateTime.UtcNow;
}