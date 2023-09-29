namespace SibGAU.Blogs.UseCases.Tags.GetAllTags;

/// <summary>
/// Tag dto.
/// </summary>
public record TagDto
{
    /// <summary>
    /// Id.
    /// </summary>
    public required int Id { get; init; }
    
    /// <summary>
    /// Name.
    /// </summary>
    public required string Name { get; init; }
}