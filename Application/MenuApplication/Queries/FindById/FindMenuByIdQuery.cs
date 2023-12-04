using MediatR;
using Application.Menu.Models;

namespace Application.Menu.Queries.FindById
{
    public class FindMenuByIdQuery : IRequest<MenuInfo>
    {
        public long Id { get; set; }
    }
}
