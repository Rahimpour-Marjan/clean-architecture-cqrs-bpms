using Application.EducationFieldApplication.Models;
using MediatR;

namespace Application.EducationFieldApplication.Queries.FindById
{
    public class FindEducationFieldByIdQuery : IRequest<EducationFieldInfo>
    {
        public int Id { get; set; }
    }
}
