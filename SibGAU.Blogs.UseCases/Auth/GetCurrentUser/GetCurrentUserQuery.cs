using MediatR;

namespace SibGAU.Blogs.UseCases.Auth.GetCurrentUser;

public class GetCurrentUserQuery : IRequest<AuthUserDto>
{
}