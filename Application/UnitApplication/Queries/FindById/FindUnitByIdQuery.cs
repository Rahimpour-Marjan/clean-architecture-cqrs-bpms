using MediatR;
using Application.UnitApplication.Models;

namespace Application.UnitApplication.Queries.FindById
{
    public class FindUnitByIdQuery : IRequest<UnitInfo>
    {
        public int Id { get; set; }
    }
}
