using MediatR;

namespace SibGAU.Blogs.UseCases.Auth.GetCurrentUserQuery;

public class GetCurrentUserQuery : IRequest<AuthUserDto>
{
    /// <summary>
    /// User name.
    /// </summary>
    public string? UserName { get; init; }
}