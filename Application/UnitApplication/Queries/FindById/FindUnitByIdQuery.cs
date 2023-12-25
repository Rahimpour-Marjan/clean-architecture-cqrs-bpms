using Application.UnitApplication.Models;
using MediatR;

namespace Application.UnitApplication.Queries.FindById
{
    public class FindUnitByIdQuery : IRequest<UnitInfo>
    {
        public int Id { get; set; }
    }
}
