using MediatR;
using Microsoft.AspNetCore.Mvc;
using SibGAU.Blogs.UseCases.Rubrics.GetAllRubrics;

namespace SibGAU.Blogs.Web.Controllers;

/// <summary>
/// Rubrics controller.
/// </summary>
[ApiController]
[Route("api/rubrics")]
public class RubricsController : ControllerBase
{
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    public RubricsController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    
    /// <summary>
    /// Get all rubrics.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Action result.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAllRubricsAsync(CancellationToken cancellationToken)
    {
        var getAllRubricsQuery = new GetAllRubricsQuery();
        var rubrics = await mediator.Send(getAllRubricsQuery, cancellationToken);
        return new JsonResult(rubrics);
    }
}