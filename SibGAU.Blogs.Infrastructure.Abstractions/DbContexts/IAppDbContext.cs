namespace SibGAU.Blogs.Infrastructure.Abstractions.DbContexts;

public interface IAppDbContext : IDbContextWithSets
{
    /// <summary>
    /// Saves all changes to database.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Number of states written to database.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}