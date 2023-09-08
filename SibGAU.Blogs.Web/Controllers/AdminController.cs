using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SibGAU.Blogs.UseCases.Auth.GetCurrentUserQuery;
using SibGAU.Blogs.UseCases.Blogs.AddBlockCommand;

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
    /// Add blog page.
    /// </summary>
    /// <returns>View.</returns>
    [HttpGet]
    public ViewResult AddBlogPage()
    {
        return View();
    }

    /// <summary>
    /// Add blog async.
    /// </summary>
    /// <param name="addBlogCommand">Add blog command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpPost]
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
}