using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
using SibGAU.Blogs.Infrastructure.Abstractions.DbContexts;

namespace SibGAU.Blogs.UseCases.Rubrics.DeleteRubric;

/// <summary>
/// Handler for delete rubric command handler.
/// </summary>
public class DeleteRubricCommandHandler : IRequestHandler<DeleteRubricCommand, Unit>
{
    private readonly IAppDbContext context;

    /// <summary>
    /// Constructor.
    /// </summary>
    public DeleteRubricCommandHandler(IAppDbContext context)
    {
        this.context = context;
    }

    /// <inheritdoc />
    public async Task<Unit> Handle(DeleteRubricCommand request, CancellationToken cancellationToken)
    {
        var rubric = await context.Rubrics
            .FirstOrDefaultAsync(rubric => rubric.Name == request.Name, cancellationToken);

        if (rubric is null)
        {
            throw new NotFoundException($"Rubric with name {request.Name} not found");
        }

        context.Rubrics.Remove(rubric);
        await context.SaveChangesAsync(cancellationToken);

        return default;
    }
}