namespace SibGAU.Blogs.UseCases.Tags.GetAllTags;

/// <summary>
/// Tag dto.
/// </summary>
public record TagDto
{
    /// <summary>
    /// Name.
    /// </summary>
    public required string Name { get; init; }
}