using MediatR;
using SibGAU.Blogs.UseCases.Blogs.GetAllBlogs;

namespace SibGAU.Blogs.UseCases.Blogs.GetBlogById;

/// <summary>
/// Get blog by id query.
/// </summary>
public record GetBlogByIdQuery : IRequest<BlogDto>
{
    /// <summary>
    /// Blog id.
    /// </summary>
    public int BlogId { get; init; }
}