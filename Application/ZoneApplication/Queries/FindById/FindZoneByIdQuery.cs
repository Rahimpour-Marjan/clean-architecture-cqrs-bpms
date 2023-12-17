using MediatR;
using Application.ZoneApplication.Models;

namespace Application.ZoneApplication.Queries.FindById
{
    public class FindZoneByIdQuery : IRequest<ZoneInfo>
    {
        public int Id { get; set; }
    }
}
