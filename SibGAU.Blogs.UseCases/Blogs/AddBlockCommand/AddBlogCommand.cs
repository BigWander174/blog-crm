using MediatR;

namespace SibGAU.Blogs.UseCases.Blogs.AddBlockCommand;

/// <summary>
/// Add blog command.
/// </summary>
public record AddBlogCommand : IRequest<Unit>
{
    /// <summary>
    /// Title.
    /// </summary>
    public required string Title { get; init; }
    
    /// <summary>
    /// Content.
    /// </summary>
    public required string Content { get; init; }
    
    /// <summary>
    /// Author id.
    /// </summary>
    public string? AuthorId { get; set; }
    
    /// <summary>
    /// Created at.
    /// </summary>
    public required DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}