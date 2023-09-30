using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SibGAU.Blogs.Domain;
using SibGAU.Blogs.Infrastructure.Abstractions.DbContexts;

namespace SibGAU.Blogs.UseCases.Blogs.AddBlog;

/// <summary>
/// Handler for add blog command.
/// </summary>
public class AddBlogCommandHandler : IRequestHandler<AddBlogCommand, Unit>
{
    private readonly IAppDbContext context;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public AddBlogCommandHandler(
        IAppDbContext context, 
        IMapper mapper
        ) 
    {
        this.context = context;
        this.mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<Unit> Handle(AddBlogCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Content))
        {
            throw new ArgumentException("Field content is null or empty");
        }

        var blog = mapper.Map<Blog>(request);
        
        await AddRubricToBlogAsync(blog, request.Rubric, cancellationToken);
        await AddTagsToBlogAsync(blog, request.Tags, cancellationToken);
        
        await context.Blogs.AddAsync(blog, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return default;
    }

    private async Task AddRubricToBlogAsync(Blog blog, string? rubricName, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(rubricName) == false)
        {
            var rubricFromDatabase = await context.Rubrics
                .FirstOrDefaultAsync(rubric => rubric.Name == rubricName, cancellationToken);
            if (rubricFromDatabase is null)
            {
                rubricFromDatabase = new Rubric()
                {
                    Name = rubricName
                };
            }

            blog.Rubric = rubricFromDatabase;
        }
    }

    private async Task AddTagsToBlogAsync(Blog blog, ICollection<string> tagNames,
        CancellationToken cancellationToken)
    {
        if (tagNames.Any() == false)
        {
            return;
        }
        tagNames = tagNames.Distinct().ToList();
        
        var tagsFromDatabase = await context.Tags
            .Where(tag => tagNames.Contains(tag.Name))
            .ToListAsync(cancellationToken);
        
        var newTags = tagNames.ExceptBy<string, Tag>(tagsFromDatabase, 
            tagName => tagsFromDatabase.FirstOrDefault(tagFromDatabase => tagFromDatabase.Name == tagName))
            .Select(newTag => new Tag
            {
                Name = newTag
            });

        var result = tagsFromDatabase.Union(newTags).ToList();

        blog.Tags = result;
    }
}