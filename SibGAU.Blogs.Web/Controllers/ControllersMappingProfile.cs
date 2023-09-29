using AutoMapper;
using SibGAU.Blogs.UseCases.Blogs.AddBlog;
using SibGAU.Blogs.Web.Controllers.Dtos;

namespace SibGAU.Blogs.Web.Controllers;

/// <summary>
/// Blogs controller mapping profile.
/// </summary>
public class ControllersMappingProfile : Profile
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public ControllersMappingProfile()
    {
        CreateMap<AddBlogDto, AddBlogCommand>();
    }    
}