using Application.ZoneApplication.Models;
using MediatR;

namespace Application.ZoneApplication.Queries.FindById
{
    public class FindZoneByIdQuery : IRequest<ZoneInfo>
    {
        public int Id { get; set; }
    }
}
