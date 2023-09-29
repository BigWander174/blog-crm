using MediatR;

namespace SibGAU.Blogs.UseCases.Tags.UpdateTag;

/// <summary>
/// Update tag command.
/// </summary>
public record UpdateTagCommand : IRequest<Unit>
{
    /// <summary>
    /// Tag id.
    /// </summary>
    public int TagId { get; set; }
    
    /// <summary>
    /// Name.
    /// </summary>
    public required string Name { get; init; }
}