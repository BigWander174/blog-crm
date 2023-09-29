using MediatR;

namespace SibGAU.Blogs.UseCases.Tags.GetAllTags;

/// <summary>
/// Get all tags query.
/// </summary>
public record GetAllTagsQuery : IRequest<IReadOnlyCollection<TagDto>>
{}