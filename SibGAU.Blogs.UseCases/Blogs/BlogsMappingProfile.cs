using AutoMapper;
using SibGAU.Blogs.Domain;
using SibGAU.Blogs.UseCases.Blogs.GetAllBlogsQuery;
using SibGAU.Blogs.UseCases.Blogs.GetBlogByIdQuery;

namespace SibGAU.Blogs.UseCases.Blogs;

/// <summary>
/// Defines rules for mapping blog to dtos.
/// </summary>
public class BlogsMappingProfile : Profile
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public BlogsMappingProfile()
    {
        CreateMap<Blog, BlogDto>()
            .ForMember(blogDto => blogDto.AuthorName, src => src.MapFrom(blog => blog.Author.UserName));
        CreateMap<Blog, GetBlogDto>();
    }
}