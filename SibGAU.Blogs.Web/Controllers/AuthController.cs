using Microsoft.AspNetCore.Mvc;
using SibGAU.Blogs.Web.Controllers.Dtos;

namespace SibGAU.Blogs.Web.Controllers;

[Route("[controller]")]
public class AuthController : Controller
{
    [HttpGet]
    public ViewResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task Login(LoginDto loginDto)
    {
        
    }
}