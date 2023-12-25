using Application.EducationSubFieldApplication.Models;
using MediatR;

namespace Application.EducationSubFieldApplication.Queries.FindById
{
    public class FindEducationSubFieldByIdQuery : IRequest<EducationSubFieldInfo>
    {
        public int Id { get; set; }
    }
}
