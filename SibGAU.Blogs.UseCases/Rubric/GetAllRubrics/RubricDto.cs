namespace SibGAU.Blogs.UseCases.Rubric.GetAllRubrics;

/// <summary>
/// Rubric dto.
/// </summary>
public record RubricDto
{
    /// <summary>
    /// Name.
    /// </summary>
    public required string Name { get; init; }
}