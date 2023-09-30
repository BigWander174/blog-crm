namespace SibGAU.Blogs.UseCases.Rubrics.GetAllRubrics;

/// <summary>
/// Rubric dto.
/// </summary>
public record RubricDto
{
    /// <summary>
    /// Id.
    /// </summary>
    public required int Id { get; init; }
    
    /// <summary>
    /// Name.
    /// </summary>
    public required string Name { get; init; }
}