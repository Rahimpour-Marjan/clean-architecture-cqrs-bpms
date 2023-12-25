using Application.EducationLevelApplication.Models;
using MediatR;


namespace Application.EducationLevelApplication.Queries.FindById
{
    public class FindEducationLevelByIdQuery : IRequest<EducationLevelInfo>
    {
        public int Id { get; set; }
    }
}
