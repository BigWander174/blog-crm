using MediatR;

namespace SibGAU.Blogs.UseCases.Auth.VerifyJwtToken;

/// <summary>
/// Verify jwt token query.
/// </summary>
public record VerifyJwtTokenQuery : IRequest<TokenVerificationDto>
{
    /// <summary>
    /// Token.
    /// </summary>
    public required string Token { get; init; }
}