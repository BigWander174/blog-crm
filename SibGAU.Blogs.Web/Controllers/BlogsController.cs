using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SibGAU.Blogs.UseCases.Auth.GetCurrentUser;
using SibGAU.Blogs.UseCases.Blogs.AddBlog;
using SibGAU.Blogs.UseCases.Blogs.DeleteBlog;
using SibGAU.Blogs.UseCases.Blogs.GetAllBlogs;
using SibGAU.Blogs.UseCases.Blogs.GetBlogById;
using SibGAU.Blogs.UseCases.Blogs.UpdateBlogCommand;
using SibGAU.Blogs.Web.Controllers.Dtos;

namespace SibGAU.Blogs.Web.Controllers;

/// <summary>
/// Blog controller.
/// </summary>
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/blogs")]
public class BlogsController : ControllerBase
{
    private readonly IMediator mediator;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public BlogsController(IMediator mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    /// <summary>
    /// Create blog.
    /// </summary>
    /// <param name="addBlogDto">Add blog command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Action result.</returns>
    [HttpPost]
    public async Task<IActionResult> CreateBlogAsync(AddBlogDto addBlogDto, CancellationToken cancellationToken)
    {
        var addBlogCommand = mapper.Map<AddBlogCommand>(addBlogDto);
        var getCurrentUserQuery = new GetCurrentUserQuery();
        var user = await mediator.Send(getCurrentUserQuery, cancellationToken);
        addBlogCommand.AuthorId = user.Id;

        await mediator.Send(addBlogCommand, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Get all blogs.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>View.</returns>
    [HttpGet]
    [AllowAnonymous]
    public async Task<JsonResult> GetAllBlogsAsync(CancellationToken cancellationToken)
    {
        var getAllBlogsQuery = new GetAllBlogsQuery();
        var blogs = await mediator.Send(getAllBlogsQuery, cancellationToken);

        return new JsonResult(blogs);
    }

    /// <summary>
    /// Get blog.
    /// </summary>
    /// <param name="getBlogByIdQuery">Get blog by id query.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>View.</returns>
    [HttpGet("{BlogId:int}")]
    [AllowAnonymous]
    public async Task<JsonResult> GetBlogAsync([FromRoute] GetBlogByIdQuery getBlogByIdQuery,
        CancellationToken cancellationToken)
    {
        var blog = await mediator.Send(getBlogByIdQuery, cancellationToken);
        return new JsonResult(blog);
    }

    /// <summary>
    /// Update blog.
    /// </summary>
    /// <param name="blogId">Blog id.</param>
    /// <param name="updateBlogCommand">Update blog command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns></returns>
    [HttpPatch("{blogId:int}")]
    public async Task<IActionResult> UpdateBlogAsync([FromRoute] int blogId,
        [FromBody] UpdateBlogCommand updateBlogCommand, CancellationToken cancellationToken)
    {
        updateBlogCommand.BlogId = blogId;
        await mediator.Send(updateBlogCommand, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Delete blog.
    /// </summary>
    /// <param name="deleteBlogCommand">Delete blog command.</param>
    /// <param name="cancellationToken">Cancellation token,</param>
    /// <returns>Action result.</returns>
    [HttpDelete("{BlogId:int}")]
    public async Task<IActionResult> DeleteBlogAsync([FromRoute] DeleteBlogCommand deleteBlogCommand, CancellationToken cancellationToken)
    {
        await mediator.Send(deleteBlogCommand, cancellationToken);
        return Ok();
    }
}