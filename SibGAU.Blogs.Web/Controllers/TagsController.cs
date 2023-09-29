using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SibGAU.Blogs.Web.Controllers;

/// <summary>
/// Tags controller.
/// </summary>
[ApiController]
[Route("api/tags")]
[Authorize]
public class TagsController : ControllerBase
{
    
}