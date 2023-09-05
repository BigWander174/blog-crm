using MediatR;
using Microsoft.AspNetCore.Mvc;
using SibGAU.Blogs.UseCases.Blogs.GetAllBlogsQuery;

namespace SibGAU.Blogs.Web.Controllers;

/// <summary>
/// Blog controller.
/// </summary>
[Route("[controller]")]
public class BlogController : Controller
{
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    public BlogController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// Get all blogs async
    /// </summary>
    /// <param name="getAllBlogsQuery"></param>
    /// <param name="cancellationToken"></param>
    [HttpGet("blogs")]
    public async Task<ViewResult> GetAllBlogsAsync(GetAllBlogsQuery getAllBlogsQuery, CancellationToken cancellationToken)
    {
        var blogs = await mediator.Send(getAllBlogsQuery, cancellationToken);
        return View(blogs);
    }
}