using AutoMapper;
using SibGAU.Blogs.Domain;
using SibGAU.Blogs.UseCases.Rubrics.GetAllRubrics;

namespace SibGAU.Blogs.UseCases.Rubrics;

/// <summary>
/// Rubrics mapping profile.
/// </summary>
public class RubricsMappingProfile : Profile
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public RubricsMappingProfile()
    {
        CreateMap<Rubric, RubricDto>();
    }
}