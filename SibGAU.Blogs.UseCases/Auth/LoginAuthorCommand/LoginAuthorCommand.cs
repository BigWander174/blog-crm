using MediatR;

namespace SibGAU.Blogs.UseCases.Auth.LoginAuthorCommand;

/// <summary>
/// Login author command.
/// </summary>
public class LoginAuthorCommand : IRequest<Unit>
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