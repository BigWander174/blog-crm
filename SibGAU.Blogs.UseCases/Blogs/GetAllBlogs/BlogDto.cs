namespace SibGAU.Blogs.UseCases.Blogs.GetAllBlogs;

/// <summary>
/// Blog dto.
/// </summary>
public class BlogDto
{
    /// <summary>
    /// Id.
    /// </summary>
    public required int Id { get; init; }
    
    /// <summary>
    /// Title.
    /// </summary>
    public required string Title { get; init; }
    
    /// <summary>
    /// Content.
    /// </summary>
    public required string Content { get; init; }
    
    /// <summary>
    /// Author.
    /// </summary>
    public required string UserName { get; set; }
    
    /// <summary>
    /// Created at.
    /// </summary>
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}