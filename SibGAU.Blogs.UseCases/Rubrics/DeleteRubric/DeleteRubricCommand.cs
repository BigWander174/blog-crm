using MediatR;

namespace SibGAU.Blogs.UseCases.Rubrics.DeleteRubric;

/// <summary>
/// Delete rubric command.
/// </summary>
public record DeleteRubricCommand : IRequest<Unit>
{
    /// <summary>
    /// Name.
    /// </summary>
    public required int RubricId { get; init; }
}