namespace SibGAU.Blogs.Web.Controllers.Dtos;

/// <summary>
/// Add blog dto.
/// </summary>
public record AddBlogDto
{
    /// <summary>
    /// Title.
    /// </summary>
    public required string Title { get; init; }
    
    /// <summary>
    /// Content.
    /// </summary>
    public required string Content { get; init; }
    
    /// <summary>
    /// Rubric.
    /// </summary>
    public string? Rubric { get; init; }
}