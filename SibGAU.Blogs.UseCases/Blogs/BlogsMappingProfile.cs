using AutoMapper;
using SibGAU.Blogs.Domain;
using SibGAU.Blogs.UseCases.Blogs.AddBlog;
using SibGAU.Blogs.UseCases.Blogs.GetAllBlogs;

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
            .ForMember(blogDto => blogDto.UserName, src => src.MapFrom(blog => blog.Author.UserName));
        CreateMap<AddBlogCommand, Blog>();
    }
}