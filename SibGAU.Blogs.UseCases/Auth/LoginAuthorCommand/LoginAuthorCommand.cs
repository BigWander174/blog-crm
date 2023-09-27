using MediatR;

namespace SibGAU.Blogs.UseCases.Auth.LoginAuthorCommand;

/// <summary>
/// Login author command.
/// </summary>
public record LoginAuthorCommand : IRequest<LoginDto>
{
    /// <summary>
    /// Login.
    /// </summary>
    public required string Email { get; init; }
    
    /// <summary>
    /// Password.
    /// </summary>
    public required string Password { get; init; }
}