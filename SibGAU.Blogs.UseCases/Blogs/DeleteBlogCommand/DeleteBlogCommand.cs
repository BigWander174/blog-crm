using MediatR;

namespace SibGAU.Blogs.UseCases.Blogs.DeleteBlogCommand;

/// <summary>
/// Delete blog command.
/// </summary>
public class DeleteBlogCommand : IRequest<Unit>
{
    /// <summary>
    /// Blog id.
    /// </summary>
    public required int BlogId { get; init; }
}