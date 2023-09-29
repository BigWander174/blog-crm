using MediatR;

namespace SibGAU.Blogs.UseCases.Rubrics.UpdateRubric;

/// <summary>
/// Update rubric command.
/// </summary>
public record UpdateRubricCommand : IRequest<Unit>
{
    /// <summary>
    /// Rubric id.
    /// </summary>
    public required int RubricId { get; set; }
    
    /// <summary>
    /// Name.
    /// </summary>
    public required string Name { get; init; }
}