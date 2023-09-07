namespace SibGAU.Blogs.Web.Controllers.Dtos;

/// <summary>
/// Login dto.
/// </summary>
public record LoginDto
{
    /// <summary>
    /// Login.
    /// </summary>
    public required string Login { get; init; }
    
    /// <summary>
    /// Password.
    /// </summary>
    public required string Password { get; init; }
}