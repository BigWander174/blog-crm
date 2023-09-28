using Extensions.Hosting.AsyncInitialization;
using Microsoft.EntityFrameworkCore;
using SibGAU.Blogs.Infrastructure.DataAccess;

namespace SibGAU.Blogs.Web.Startup.Initializers;

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

    /// <inheritdoc />
    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        await context.Database.MigrateAsync(cancellationToken);
    }
}