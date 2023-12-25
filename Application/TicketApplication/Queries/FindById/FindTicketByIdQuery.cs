using Application.Ticket.Models;
using MediatR;

namespace Application.Ticket.Queries.FindById
{
    public class FindTicketByIdQuery : IRequest<TicketInfo>
    {
        public int Id { get; set; }
    }
}
