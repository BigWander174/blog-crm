using MediatR;

namespace SibGAU.Blogs.UseCases.Blogs.GetAllBlogs;

/// <summary>
/// Get all blogs query.
/// </summary>
public record GetAllBlogsQuery : IRequest<IReadOnlyCollection<BlogDto>>
{
}