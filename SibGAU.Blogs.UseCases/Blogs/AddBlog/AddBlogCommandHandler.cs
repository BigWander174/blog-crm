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
        var blog = mapper.Map<Blog>(request);
        if (string.IsNullOrEmpty(request.Rubric) == false)
        {
            var rubricFromDatabase = await context.Rubrics
                .FirstOrDefaultAsync(rubric => rubric.Name == request.Rubric, cancellationToken);
            if (rubricFromDatabase is null)
            {
                rubricFromDatabase = new Rubric()
                {
                    Name = request.Rubric
                };
            }

            blog.Rubric = rubricFromDatabase;
        }

        await context.Blogs.AddAsync(blog, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return default;
    }
}