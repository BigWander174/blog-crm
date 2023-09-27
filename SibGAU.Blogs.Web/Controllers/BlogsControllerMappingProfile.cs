using AutoMapper;
using SibGAU.Blogs.UseCases.Blogs.AddBlogCommand;
using SibGAU.Blogs.Web.Controllers.Dtos;

namespace SibGAU.Blogs.Web.Controllers;

/// <summary>
/// Blogs controller mapping profile.
/// </summary>
public class BlogsControllerMappingProfile : Profile
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public BlogsControllerMappingProfile()
    {
        CreateMap<AddBlogDto, AddBlogCommand>();
    }    
}