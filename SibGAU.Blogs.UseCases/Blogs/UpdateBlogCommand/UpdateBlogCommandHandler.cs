using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
using SibGAU.Blogs.Domain;
using SibGAU.Blogs.Infrastructure.Abstractions.DbContexts;

namespace SibGAU.Blogs.UseCases.Blogs.UpdateBlogCommand;

/// <summary>
/// Update blog command handler.
/// </summary>
public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, Unit>
{
    private readonly IAppDbContext context;

    /// <summary>
    /// Constructor.
    /// </summary>
    public UpdateBlogCommandHandler(IAppDbContext context)
    {
        this.context = context;
    }

    /// <inheritdoc />
    public async Task<Unit> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        var blog = await context.Blogs
            .Include(blog => blog.Rubric)
            .FirstOrDefaultAsync(blog => blog.Id == request.BlogId, cancellationToken);
        if (blog is null)
        {
            throw new NotFoundException("blog not found");
        }

        if (request.NewRubric is not null)
        {
            var rubric = await context.Rubrics
                .FirstOrDefaultAsync(blog => blog.Name == request.NewRubric, cancellationToken);
            if (rubric is null)
            {
                rubric = new Rubric()
                {
                    Name = request.NewRubric
                };
            }

            blog.Rubric = rubric;
        }

        if (request.Title is not null)
        {
            blog.Title = request.Title;
            blog.EditedAt = DateTime.UtcNow;
        }

        if (request.Content is not null)
        {
            blog.Content = request.Content;
            blog.EditedAt = DateTime.UtcNow;
        }

        await context.SaveChangesAsync(cancellationToken);
        return default;
    }
}