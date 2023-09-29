using MediatR;

namespace SibGAU.Blogs.UseCases.Rubric.GetAllRubrics;

/// <summary>
/// Get all rubrics query.
/// </summary>
public record GetAllRubricsQuery : IRequest<IReadOnlyCollection<RubricDto>>
{}