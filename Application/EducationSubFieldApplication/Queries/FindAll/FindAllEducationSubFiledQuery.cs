using MediatR;
using Application.EducationSubFieldApplication.Models;
using Application.Common;

namespace Application.EducationSubFieldApplication.Queries.FindAll
{
    public class FindAllEducationSubFieldQuery : IRequest<FindAllQueryResponse<IList<EducationSubFieldInfo>>>
    {
        public int? EducationFieldId { get; set; }
        public string? Query { get; set; }
    }
}
