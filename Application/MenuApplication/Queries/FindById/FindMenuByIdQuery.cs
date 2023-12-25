using Application.Menu.Models;
using MediatR;

namespace Application.Menu.Queries.FindById
{
    public class FindMenuByIdQuery : IRequest<MenuInfo>
    {
        public long Id { get; set; }
    }
}
