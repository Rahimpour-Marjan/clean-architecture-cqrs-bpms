using MediatR;
using Application.EducationLevelApplication.Models;


namespace Application.EducationLevelApplication.Queries.FindById
{
    public class FindEducationLevelByIdQuery : IRequest<EducationLevelInfo>
    {
        public int Id { get; set; }
    }
}
