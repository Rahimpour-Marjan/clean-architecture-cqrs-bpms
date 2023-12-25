using Application.Common;
using Application.EducationLevelApplication.Models;
using MediatR;

namespace Application.EducationLevelApplication.Queries.FindAll
{
    public class FindAllEducationLevelQuery : IRequest<FindAllQueryResponse<IList<EducationLevelInfo>>>
    {
        public string? Query { get; set; }
    }
}
