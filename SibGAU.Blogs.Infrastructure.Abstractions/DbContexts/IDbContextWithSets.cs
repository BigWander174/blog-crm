using Microsoft.EntityFrameworkCore;
using SibGAU.Blogs.Domain;

namespace SibGAU.Blogs.Infrastructure.Abstractions.DbContexts;

/// <summary>
/// Contains entities in database.
/// </summary>
public interface IDbContextWithSets
{
    /// <summary>
    /// Authors.
    /// </summary>
    DbSet<Author> Authors { get; set; }
    
    /// <summary>
    /// Blogs.
    /// </summary>
    DbSet<Blog> Blogs { get; set; }
    
    /// <summary>
    /// Rubrics.
    /// </summary>
    DbSet<Rubric> Rubrics { get; set; }
    
    /// <summary>
    /// Tags.
    /// </summary>
    DbSet<Tag> Tags { get; set; }
}