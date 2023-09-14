using MediatR;
using Microsoft.AspNetCore.Mvc;
using SibGAU.Blogs.UseCases.Blogs.GetAllBlogsQuery;
using SibGAU.Blogs.UseCases.Blogs.GetBlogByIdQuery;

namespace SibGAU.Blogs.Web.Controllers;

/// <summary>
/// Blog controller.
/// </summary>
[Route("[controller]")]
public class BlogsController : Controller
{
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    public BlogsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<ViewResult> GetAllBlogsPage(CancellationToken cancellationToken)
    {
        var getAllBlogsQuery = new GetAllBlogsQuery();
        var blogs = await mediator.Send(getAllBlogsQuery, cancellationToken);

        return View(blogs);
    }

    [HttpGet("{BlogId:int}")]
    public async Task<ViewResult> GetBlogPage([FromRoute] GetBlogByIdQuery getBlogByIdQuery,
        CancellationToken cancellationToken)
    {
        var blog = await mediator.Send(getBlogByIdQuery, cancellationToken);
        return View(blog);
    }
}