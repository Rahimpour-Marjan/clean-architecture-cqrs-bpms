using MediatR;
using Application.EducationFieldApplication.Models;
using Application.Common;

namespace Application.EducationFieldApplication.Queries.FindAll
{
    public class FindAllEducationFieldQuery : IRequest<FindAllQueryResponse<IList<EducationFieldInfo>>>
    {
        public string? Query { get; set; }
    }
}
