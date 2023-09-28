using MediatR;

namespace SibGAU.Blogs.UseCases.Blogs.AddBlog;

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
    /// Short description.
    /// </summary>
    public required string ShortDescription { get; set; }
    
    /// <summary>
    /// Content.
    /// </summary>
    public required string Content { get; init; }
    
    /// <summary>
    /// Author id.
    /// </summary>
    public required string AuthorId { get; set; }
}