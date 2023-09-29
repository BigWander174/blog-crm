namespace SibGAU.Blogs.Web.Controllers.Dtos;

/// <summary>
/// Update tag dto.
/// </summary>
public record UpdateTagDto
{
    /// <summary>
    /// Name.
    /// </summary>
    public required string Name { get; init; }
}