using MediatR;

namespace SibGAU.Blogs.UseCases.Blogs.DeleteBlog;

/// <summary>
/// Delete blog command.
/// </summary>
public record DeleteBlogCommand : IRequest<Unit>
{
    /// <summary>
    /// Blog id.
    /// </summary>
    public required int BlogId { get; init; }
}