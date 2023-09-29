using MediatR;

namespace SibGAU.Blogs.UseCases.Tags.DeleteTag;

/// <summary>
/// Delete tag command.
/// </summary>
public record DeleteTagCommand : IRequest<Unit>
{
    /// <summary>
    /// Tag id.
    /// </summary>
    public int TagId { get; init; }
}