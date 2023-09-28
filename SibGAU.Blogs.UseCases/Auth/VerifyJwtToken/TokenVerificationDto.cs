namespace SibGAU.Blogs.UseCases.Auth.VerifyJwtToken;

/// <summary>
/// Token verification dto.
/// </summary>
public record TokenVerificationDto
{
    /// <summary>
    /// Is valid.
    /// </summary>
    public required bool IsValid { get; init; }
}