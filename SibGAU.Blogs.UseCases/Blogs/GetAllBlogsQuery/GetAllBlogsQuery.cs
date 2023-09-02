using MediatR;

namespace SibGAU.Blogs.UseCases.Blogs.GetAllBlogsQuery;

/// <summary>
/// Get all blogs query.
/// </summary>
public class GetAllBlogsQuery : IRequest<IReadOnlyCollection<BlogDto>>
{
}