using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
using SibGAU.Blogs.Infrastructure.Abstractions.DbContexts;

namespace SibGAU.Blogs.UseCases.Rubrics.UpdateRubric;

/// <summary>
/// Handler for update rubric command.
/// </summary>
public class UpdateRubricCommandHandler : IRequestHandler<UpdateRubricCommand, Unit>
{
    private readonly IAppDbContext context;

    /// <summary>
    /// Constructor.
    /// </summary>
    public UpdateRubricCommandHandler(IAppDbContext context)
    {
        this.context = context;
    }

    /// <inheritdoc />
    public async Task<Unit> Handle(UpdateRubricCommand request, CancellationToken cancellationToken)
    {
        var rubricFromDatabase = await context.Rubrics
            .FirstOrDefaultAsync(rubric => rubric.Id == request.RubricId, cancellationToken);

        if (rubricFromDatabase is null)
        {
            throw new NotFoundException($"Rubric with id {request.RubricId} not found");
        }

        rubricFromDatabase.Name = request.Name;

        await context.SaveChangesAsync(cancellationToken);

        return default;
    }
}