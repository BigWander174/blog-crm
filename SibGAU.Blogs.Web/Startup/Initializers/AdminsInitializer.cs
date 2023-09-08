using Extensions.Hosting.AsyncInitialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Saritasa.Tools.Domain.Exceptions;
using SibGAU.Blogs.Domain;
using SibGAU.Blogs.Web.Startup.Settings;

namespace SibGAU.Blogs.Web.Startup.Initializers;

public class AdminsInitializer : IAsyncInitializer
{
    private readonly RoleManager<IdentityRole> roleManager;
    private readonly List<AdminCredentials> credentials;
    private readonly UserManager<Author> userManager;
    private readonly ILogger<AdminsInitializer> logger;

    public AdminsInitializer(RoleManager<IdentityRole> roleManager, 
        IOptions<List<AdminCredentials>> credentials, 
        UserManager<Author> userManager, 
        ILogger<AdminsInitializer> logger)
    {
        this.roleManager = roleManager;
        this.userManager = userManager;
        this.logger = logger;
        this.credentials = credentials.Value;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
        foreach (var credential in credentials)
        {
            if (credential.Username is null)
            {
                throw new ArgumentException("Login for one of admins not provided", nameof(credential.Username));
            }

            if (credential.Password is null)
            {
                throw new ArgumentException("Password for one of admins not provided", nameof(credential.Password));
            }

            var user = await userManager.FindByEmailAsync(credential.Email);
            if (user is not null)
            {
                continue;
            }
            var author = new Author()
            {
                UserName = credential.Username,
                Email = credential.Email
            };
            var result = await userManager.CreateAsync(author, credential.Password);
            if (result.Succeeded == false)
            {
                logger.LogError("Something went wrong by adding admin with credentials {Email} {Password}", credential.Username, credential.Password);
                throw new DomainException("Something went wrong by creating user");
            }

            var adminRoleAddResult = await userManager.AddToRoleAsync(author, "Admin");
            if (adminRoleAddResult.Succeeded == false)
            {
                logger.LogError("Something went wrong by updating user {Email} role to admin", credential.Username);
                throw new DomainException("Something went wrong by adding admin role to user");
            }
        }
    }
}