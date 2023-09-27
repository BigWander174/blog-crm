using SibGAU.Blogs.UseCases.Blogs.GetAllBlogsQuery;

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
    
    /// <summary>
    /// User name.
    /// </summary>
    public required string UserName { get; init; }

    /// <summary>
    /// Blog dtos.
    /// </summary>
    public ICollection<BlogDto> Blogs { get; init; } = new List<BlogDto>();
    
    /// <summary>
    /// Email.
    /// </summary>
    public required string Email { get; init; }
}