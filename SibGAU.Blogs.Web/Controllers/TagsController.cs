using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SibGAU.Blogs.UseCases.Tags;
using SibGAU.Blogs.UseCases.Tags.GetAllTags;

namespace SibGAU.Blogs.Web.Controllers;

/// <summary>
/// Tags controller.
/// </summary>
[ApiController]
[Route("api/tags")]
[Authorize]
public class TagsController : ControllerBase
{
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    public TagsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// Get all tags.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllTagsAsync(CancellationToken cancellationToken)
    {
        var getAllTagsQuery = new GetAllTagsQuery();
        var result = await mediator.Send(getAllTagsQuery, cancellationToken);

        return Ok(result);
    }
}