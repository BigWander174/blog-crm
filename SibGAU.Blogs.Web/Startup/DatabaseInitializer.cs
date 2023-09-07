using Extensions.Hosting.AsyncInitialization;
using SibGAU.Blogs.Infrastructure.DataAccess;

namespace SibGAU.Blogs.Web.Startup;

/// <summary>
/// Initializes database.
/// </summary>
public class DatabaseInitializer : IAsyncInitializer
{
    private readonly AppDbContext context;

    /// <summary>
    /// Constructor.
    /// </summary>
    public DatabaseInitializer(AppDbContext context)
    {
        this.context = context;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        await context.Database.EnsureCreatedAsync(cancellationToken);
    }
}