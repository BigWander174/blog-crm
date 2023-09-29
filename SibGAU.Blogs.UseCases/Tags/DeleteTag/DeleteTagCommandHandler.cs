using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
using SibGAU.Blogs.Infrastructure.Abstractions.DbContexts;

namespace SibGAU.Blogs.UseCases.Tags.DeleteTag;

/// <summary>
/// Handler for delete tag command.
/// </summary>
public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, Unit>
{
    private readonly IAppDbContext context;

    /// <summary>
    /// Constructor.
    /// </summary>
    public DeleteTagCommandHandler(IAppDbContext context)
    {
        this.context = context;
    }

    /// <inheritdoc />
    public async Task<Unit> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
    {
        var tag = await context.Tags
            .FirstOrDefaultAsync(tag => tag.Id == request.TagId, cancellationToken);

        if (tag is null)
        {
            throw new NotFoundException($"Tag with id {request.TagId} not found");
        }

        context.Tags.Remove(tag);
        await context.SaveChangesAsync(cancellationToken);
        return default;
    }
}