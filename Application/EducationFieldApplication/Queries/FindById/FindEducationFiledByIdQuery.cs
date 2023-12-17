using MediatR;
using Application.EducationFieldApplication.Models;

namespace Application.EducationFieldApplication.Queries.FindById
{
    public class FindEducationFieldByIdQuery : IRequest<EducationFieldInfo>
    {
        public int Id { get; set; }
    }
}
