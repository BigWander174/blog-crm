using Microsoft.EntityFrameworkCore;
using SibGAU.Blogs.Domain;
using SibGAU.Blogs.Infrastructure.Abstractions.DbContexts;

namespace SibGAU.Blogs.Infrastructure.DataAccess;

public class AppDbContext : DbContext, IAppDbContext, IReadOnlyAppDbContext
{
    /// <summary>
    /// App db context.
    /// </summary>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    /// <inheritdoc />
    public DbSet<Author> Authors { get; set; }

    /// <inheritdoc />
    public DbSet<Blog> Blogs { get; set; }
}