using MediatR;

namespace SibGAU.Blogs.UseCases.Rubrics.CreateRubric;

/// <summary>
/// Create rubric command.
/// </summary>
public record CreateRubricCommand : IRequest<Unit>
{
    /// <summary>
    /// Name.
    /// </summary>
    public required string Name { get; init; }
}