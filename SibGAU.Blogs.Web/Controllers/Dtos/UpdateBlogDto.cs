namespace SibGAU.Blogs.Web.Controllers.Dtos;

/// <summary>
/// Update blog dto.
/// </summary>
public class UpdateBlogDto
{
    /// <summary>
    /// Title.
    /// </summary>
    public string? Title { get; init; }
    
    /// <summary>
    /// Content.
    /// </summary>
    public string? Content { get; init; }
    
    /// <summary>
    /// New rubric.
    /// </summary>
    public string? NewRubric { get; init; }
}