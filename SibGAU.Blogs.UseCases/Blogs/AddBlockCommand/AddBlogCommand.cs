using MediatR;

namespace SibGAU.Blogs.UseCases.Blogs.AddBlockCommand;

/// <summary>
/// Add blog command.
/// </summary>
public class AddBlogCommand : IRequest<Unit>
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
    public required int AuthorId { get; init; }
    
    /// <summary>
    /// Created at.
    /// </summary>
    public required DateTime CreatedAt { get; init; } = DateTime.Now;
}