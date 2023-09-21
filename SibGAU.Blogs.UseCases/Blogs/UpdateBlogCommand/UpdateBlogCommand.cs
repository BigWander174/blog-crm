using MediatR;

namespace SibGAU.Blogs.UseCases.Blogs.UpdateBlogCommand;

/// <summary>
/// Update blog command.
/// </summary>
public record UpdateBlogCommand : IRequest<Unit>
{
    /// <summary>
    /// Blog id.
    /// </summary>
    public required int BlogId { get; set; }
    
    /// <summary>
    /// Title.
    /// </summary>
    public string? Title { get; init; }
    
    /// <summary>
    /// Short description.
    /// </summary>
    public string? ShortDescription { get; init; }
    
    /// <summary>
    /// Content.
    /// </summary>
    public string? Content { get; init; }
    
    /// <summary>
    /// Edited at.
    /// </summary>
    public DateTime EditedAt { get; init; } = DateTime.UtcNow;
}