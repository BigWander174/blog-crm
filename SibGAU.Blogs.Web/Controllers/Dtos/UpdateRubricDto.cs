namespace SibGAU.Blogs.Web.Controllers.Dtos;

/// <summary>
/// Update rubric dto.
/// </summary>
public record UpdateRubricDto
{
    /// <summary>
    /// Name.
    /// </summary>
    public required string Name { get; init; }
}