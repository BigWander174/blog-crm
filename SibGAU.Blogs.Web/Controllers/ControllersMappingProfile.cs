using AutoMapper;
using SibGAU.Blogs.UseCases.Blogs.AddBlog;
using SibGAU.Blogs.UseCases.Blogs.UpdateBlogCommand;
using SibGAU.Blogs.UseCases.Rubrics.UpdateRubric;
using SibGAU.Blogs.UseCases.Tags.UpdateTag;
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

        CreateMap<UpdateBlogDto, UpdateBlogCommand>();

        CreateMap<UpdateRubricDto, UpdateRubricCommand>();

        CreateMap<UpdateTagDto, UpdateTagCommand>();
    }    
}