namespace SibGAU.Blogs.Web.Controllers.Dtos;

/// <summary>
/// Add blog dto.
/// </summary>
public class AddBlogDto
{
    /// <summary>
    /// Title.
    /// </summary>
    public required string Title { get; init; }
    
    /// <summary>
    /// Short description.
    /// </summary>
    public required string ShortDescription { get; set; }
    
    /// <summary>
    /// Content.
    /// </summary>
    public required string Content { get; init; }
}