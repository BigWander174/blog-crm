using MediatR;

namespace SibGAU.Blogs.UseCases.Blogs.UpdateBlogCommand;

/// <summary>
/// Update blog command.
/// </summary>
public class UpdateBlogCommand : IRequest<Unit>
{
    /// <summary>
    /// Blog id.
    /// </summary>
    public required int BlogId { get; init; }
    
    /// <summary>
    /// Title.
    /// </summary>
    public string? Title { get; init; }
    
    /// <summary>
    /// Content.
    /// </summary>
    public string? Content { get; init; }
    
    /// <summary>
    /// Edited at.
    /// </summary>
    public DateTime EditedAt { get; init; } = DateTime.Now;
}