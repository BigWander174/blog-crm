namespace SibGAU.Blogs.UseCases.Auth.GetCurrentUserQuery;

/// <summary>
/// Auth user dto.
/// </summary>
public record AuthUserDto
{
    /// <summary>
    /// User name.
    /// </summary>
    public required string Id { get; init; }
}