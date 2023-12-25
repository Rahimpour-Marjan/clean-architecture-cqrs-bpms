using MediatR;
using Application.EducationSubFieldApplication.Models;

namespace Application.EducationSubFieldApplication.Queries.FindById
{
    public class FindEducationSubFieldByIdQuery : IRequest<EducationSubFieldInfo>
    {
        public int Id { get; set; }
    }
}
