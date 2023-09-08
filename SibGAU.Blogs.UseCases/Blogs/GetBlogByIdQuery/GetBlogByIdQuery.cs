using MediatR;

namespace SibGAU.Blogs.UseCases.Blogs.GetBlogByIdQuery;

/// <summary>
/// Get blog by id query.
/// </summary>
public class GetBlogByIdQuery : IRequest<GetBlogDto>
{
    /// <summary>
    /// Blog id.
    /// </summary>
    public required int BlogId { get; init; }
}