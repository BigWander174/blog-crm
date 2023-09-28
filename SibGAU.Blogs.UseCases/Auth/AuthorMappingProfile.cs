using AutoMapper;
using SibGAU.Blogs.Domain;
using SibGAU.Blogs.UseCases.Auth.GetCurrentUser;

namespace SibGAU.Blogs.UseCases.Auth;

/// <summary>
/// Author mapping profile.
/// </summary>
public class AuthorMappingProfile : Profile
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public AuthorMappingProfile()
    {
        CreateMap<Author, AuthUserDto>();
    }
}