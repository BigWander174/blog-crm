namespace SibGAU.Blogs.UseCases.Auth.LoginAuthor;

/// <summary>
/// Login dto.
/// </summary>
public class LoginDto
{
    /// <summary>
    /// Access token.
    /// </summary>
    public required string AccessToken { get; init; }
    
    /// <summary>
    /// Expires in seconds.
    /// </summary>
    public required int ExpiresInSeconds { get; init; }
}