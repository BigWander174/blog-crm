using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using SibGAU.Blogs.Domain;
using SibGAU.Blogs.Infrastructure.Abstractions.DbContexts;

namespace SibGAU.Blogs.UseCases.Rubrics.CreateRubric;

/// <summary>
/// Handler for create rubric command.
/// </summary>
public class CreateRubricCommandHandler : IRequestHandler<CreateRubricCommand, Unit>
{
    private readonly IAppDbContext context;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateRubricCommandHandler(IAppDbContext context)
    {
        this.context = context;
    }

    /// <inheritdoc />
    public async Task<Unit> Handle(CreateRubricCommand request, CancellationToken cancellationToken)
    {
        var isRubricExist = context.Rubrics.Any(rubric => rubric.Name == request.Name);
        if (isRubricExist)
        {
            throw new DomainException($"Rubric with name {request.Name} already exist");
        }

        var newRubric = new Rubric()
        {
            Name = request.Name
        };

        await context.Rubrics.AddAsync(newRubric, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return default;
    }
}