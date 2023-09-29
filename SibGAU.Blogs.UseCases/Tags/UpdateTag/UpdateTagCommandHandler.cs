using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
using SibGAU.Blogs.Infrastructure.Abstractions.DbContexts;

namespace SibGAU.Blogs.UseCases.Tags.UpdateTag;

/// <summary>
/// Handler for update tag command.
/// </summary>
public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, Unit>
{
    private readonly IAppDbContext context;

    /// <summary>
    /// Constructor.
    /// </summary>
    public UpdateTagCommandHandler(IAppDbContext context)
    {
        this.context = context;
    }

    /// <inheritdoc />
    public async Task<Unit> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
    {
        var tag = await context.Tags
            .FirstOrDefaultAsync(tag => tag.Id == request.TagId, cancellationToken);

        if (tag is null)
        {
            throw new NotFoundException($"Tag with id {request.TagId} not found");
        }

        tag.Name = request.Name;

        await context.SaveChangesAsync(cancellationToken);

        return default;
    }
}