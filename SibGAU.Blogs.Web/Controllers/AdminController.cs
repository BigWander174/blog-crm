using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SibGAU.Blogs.UseCases.Auth.GetCurrentUserQuery;
using SibGAU.Blogs.UseCases.Blogs.AddBlockCommand;
using SibGAU.Blogs.UseCases.Blogs.DeleteBlogCommand;
using SibGAU.Blogs.UseCases.Blogs.GetAllBlogsQuery;
using SibGAU.Blogs.UseCases.Blogs.GetBlogByIdQuery;
using SibGAU.Blogs.UseCases.Blogs.UpdateBlogCommand;

namespace SibGAU.Blogs.Web.Controllers;

/// <summary>
/// Admin controller.
/// </summary>
[Route("[controller]")]
[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    public AdminController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    
    /// <summary>
    /// Get all blogs page.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>View.</returns>
    [HttpGet("blogs")]
    public async Task<ViewResult> GetAllBlogsPage(CancellationToken cancellationToken)
    {
        var getAllBlogsQuery = new GetAllBlogsQuery();
        var blogs = await mediator.Send(getAllBlogsQuery, cancellationToken);

        return View(blogs);
    }

    /// <summary>
    /// Add blog page.
    /// </summary>
    /// <returns>View.</returns>
    [HttpGet("blogs/add")]
    public ViewResult AddBlogPage()
    {
        return View();
    }

    /// <summary>
    /// Add blog async.
    /// </summary>
    /// <param name="addBlogCommand">Add blog command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpPost("blogs")]
    public async Task AddBlogAsync(AddBlogCommand addBlogCommand, CancellationToken cancellationToken)
    {
        var getUserQuery = new GetCurrentUserQuery()
        {
            UserName = User.Identity?.Name
        };

        var userDto = await mediator.Send(getUserQuery, cancellationToken);
        addBlogCommand.AuthorId = userDto.Id;
        await mediator.Send(addBlogCommand, cancellationToken);
    }

    /// <summary>
    /// Update blog page.
    /// </summary>
    /// <param name="getBlogByIdQuery">Get blog by id query.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Blog id.</returns>
    [HttpGet("blogs/{BlogId}")]
    public async Task<ViewResult> UpdateBlogPage([FromRoute] GetBlogByIdQuery getBlogByIdQuery, CancellationToken cancellationToken)
    {
        var blog = await mediator.Send(getBlogByIdQuery, cancellationToken);
        return View(blog);
    }

    /// <summary>
    /// Update blog.
    /// </summary>
    /// <param name="blogId">Blog id.</param>
    /// <param name="updateBlogCommand">Update blog command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpPost("blogs/{blogId:int}")]
    public async Task UpdateBlogAsync([FromRoute] int blogId, [FromForm] UpdateBlogCommand updateBlogCommand, CancellationToken cancellationToken)
    {
        updateBlogCommand.BlogId = blogId;
        await mediator.Send(updateBlogCommand, cancellationToken);
    }

    /// <summary>
    /// Delete blog from database.
    /// </summary>
    /// <param name="blogId">blog id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpPost("{blogId:int}")]
    public async Task<RedirectToActionResult> DeleteBlogAsync([FromRoute] int blogId, CancellationToken cancellationToken)
    {
        var deleteBlogCommand = new DeleteBlogCommand()
        {
            BlogId = blogId
        };
        await mediator.Send(deleteBlogCommand, cancellationToken);
        return RedirectToAction("GetAllBlogsPage");
    }
}