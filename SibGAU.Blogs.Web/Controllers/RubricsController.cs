using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SibGAU.Blogs.UseCases.Rubrics.CreateRubric;
using SibGAU.Blogs.UseCases.Rubrics.DeleteRubric;
using SibGAU.Blogs.UseCases.Rubrics.GetAllRubrics;

namespace SibGAU.Blogs.Web.Controllers;

/// <summary>
/// Rubrics controller.
/// </summary>
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
    /// Create rubric.
    /// </summary>
    /// <param name="createRubricCommand">Create rubric command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Action result.</returns>
    [HttpPost]
    public async Task<IActionResult> CreateRubricAsync(CreateRubricCommand createRubricCommand,
        CancellationToken cancellationToken)
    {
        await mediator.Send(createRubricCommand, cancellationToken);
        return Ok();
    }
    
    /// <summary>
    /// Get all rubrics.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Action result.</returns>
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllRubricsAsync(CancellationToken cancellationToken)
    {
        var getAllRubricsQuery = new GetAllRubricsQuery();
        var rubrics = await mediator.Send(getAllRubricsQuery, cancellationToken);
        return new JsonResult(rubrics);
    }

    /// <summary>
    /// Delete rubric.
    /// </summary>
    /// <param name="deleteRubricCommand">Delete rubric command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Action result.</returns>
    [HttpDelete]
    public async Task<IActionResult> DeleteRubricAsync(DeleteRubricCommand deleteRubricCommand, CancellationToken cancellationToken)
    {
        await mediator.Send(deleteRubricCommand, cancellationToken);
        return Ok();
    }
}