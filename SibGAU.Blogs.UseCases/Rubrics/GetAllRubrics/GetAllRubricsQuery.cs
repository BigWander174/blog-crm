using MediatR;

namespace SibGAU.Blogs.UseCases.Rubrics.GetAllRubrics;

/// <summary>
/// Get all rubrics query.
/// </summary>
public record GetAllRubricsQuery : IRequest<IReadOnlyCollection<RubricDto>>
{}