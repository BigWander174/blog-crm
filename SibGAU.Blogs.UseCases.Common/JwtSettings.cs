namespace SibGAU.Blogs.UseCases.Common;

/// <summary>
/// Jwt settings.
/// </summary>
public class JwtSettings
{
    /// <summary>
    /// Issuer.
    /// </summary>
    public required string Issuer { get; init; }
    
    /// <summary>
    /// Audience.
    /// </summary>
    public required string Audience { get; init; }
    
    /// <summary>
    /// Secret key.
    /// </summary>
    public required string SecretKey { get; init; }
    
    /// <summary>
    /// Duration.
    /// </summary>
    public required int DurationMinutes { get; init; }
}