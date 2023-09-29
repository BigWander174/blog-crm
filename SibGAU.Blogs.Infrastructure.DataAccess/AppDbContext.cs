using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SibGAU.Blogs.Domain;
using SibGAU.Blogs.Infrastructure.Abstractions.DbContexts;

namespace SibGAU.Blogs.Infrastructure.DataAccess;

public class AppDbContext : IdentityDbContext<Author>, IAppDbContext
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

    /// <inheritdoc />
    public DbSet<Rubric> Rubrics { get; set; }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Rubric>()
            .HasMany(rubric => rubric.Blogs)
            .WithOne(blog => blog.Rubric)
            .OnDelete(DeleteBehavior.SetNull);
    }
}