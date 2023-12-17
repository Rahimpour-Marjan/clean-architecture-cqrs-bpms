using MediatR;
using Application.EducationLevelApplication.Models;
using Application.Common;

namespace Application.EducationLevelApplication.Queries.FindAll
{
    public class FindAllEducationLevelQuery : IRequest<FindAllQueryResponse<IList<EducationLevelInfo>>>
    {
        public string? Query { get; set; }
    }
}
