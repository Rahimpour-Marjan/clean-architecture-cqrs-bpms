using Application.Common;
using Application.EducationFieldApplication.Models;
using MediatR;

namespace Application.EducationFieldApplication.Queries.FindAll
{
    public class FindAllEducationFieldQuery : IRequest<FindAllQueryResponse<IList<EducationFieldInfo>>>
    {
        public string? Query { get; set; }
    }
}
