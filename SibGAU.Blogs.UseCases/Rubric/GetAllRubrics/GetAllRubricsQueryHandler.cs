using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SibGAU.Blogs.Infrastructure.Abstractions.DbContexts;

namespace SibGAU.Blogs.UseCases.Rubric.GetAllRubrics;

/// <summary>
/// Handler for get all rubrics query.
/// </summary>
public class GetAllRubricsQueryHandler : IRequestHandler<GetAllRubricsQuery, IReadOnlyCollection<RubricDto>>
{
    private readonly IAppDbContext context;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAllRubricsQueryHandler(
        IAppDbContext context, 
        IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<RubricDto>> Handle(GetAllRubricsQuery request, CancellationToken cancellationToken)
    {
        return await context.Rubrics
            .AsNoTracking()
            .ProjectTo<RubricDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}