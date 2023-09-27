using AutoMapper;
using SibGAU.Blogs.Domain;
using SibGAU.Blogs.UseCases.Auth.GetCurrentUserQuery;
using SibGAU.Blogs.UseCases.Blogs.GetAllBlogsQuery;

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
        CreateMap<Blog, BlogDto>();
        CreateMap<Author, AuthUserDto>();
    }
}