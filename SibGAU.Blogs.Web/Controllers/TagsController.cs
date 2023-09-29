using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SibGAU.Blogs.UseCases.Tags.GetAllTags;
using SibGAU.Blogs.UseCases.Tags.UpdateTag;
using SibGAU.Blogs.Web.Controllers.Dtos;

namespace SibGAU.Blogs.Web.Controllers;

/// <summary>
/// Tags controller.
/// </summary>
[ApiController]
[Route("api/tags")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class TagsController : ControllerBase
{
    private readonly IMediator mediator;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public TagsController(IMediator mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
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

    /// <summary>
    /// Update tag.
    /// </summary>
    /// <param name="tagId">Tag id.</param>
    /// <param name="updateTagDto">Update tag dto.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Action result.</returns>
    [HttpPatch("{tagId:int}")]
    public async Task<IActionResult> UpdateTagAsync([FromRoute] int tagId, [FromBody] UpdateTagDto updateTagDto,
        CancellationToken cancellationToken)
    {
        var updateTagCommand = mapper.Map<UpdateTagCommand>(updateTagDto);
        updateTagCommand.TagId = tagId;

        await mediator.Send(updateTagCommand, cancellationToken);
        return Ok();
    }
}