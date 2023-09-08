namespace SibGAU.Blogs.UseCases.Blogs.GetBlogByIdQuery;

/// <summary>
/// Get blog dto.
/// </summary>
public class GetBlogDto
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
}