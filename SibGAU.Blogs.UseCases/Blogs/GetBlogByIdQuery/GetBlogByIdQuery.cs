using MediatR;

namespace SibGAU.Blogs.UseCases.Blogs.GetBlogByIdQuery;

/// <summary>
/// Get blog by id query.
/// </summary>
public record GetBlogByIdQuery : IRequest<GetBlogDto>
{
    /// <summary>
    /// Blog id.
    /// </summary>
    public int BlogId { get; init; }
}