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
    public int BlogId { get; set; }
    
    /// <summary>
    /// Title.
    /// </summary>
    public string? Title { get; init; }
    
    /// <summary>
    /// Content.
    /// </summary>
    public string? Content { get; init; }
    
    /// <summary>
    /// New rubric.
    /// </summary>
    public string? NewRubric { get; init; }
}