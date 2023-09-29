using AutoMapper;
using SibGAU.Blogs.Domain;
using SibGAU.Blogs.UseCases.Tags.GetAllTags;

namespace SibGAU.Blogs.UseCases.Tags;

/// <summary>
/// Tag mapping profile.
/// </summary>
public class TagMappingProfile : Profile
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public TagMappingProfile()
    {
        CreateMap<Tag, TagDto>();
    }
}