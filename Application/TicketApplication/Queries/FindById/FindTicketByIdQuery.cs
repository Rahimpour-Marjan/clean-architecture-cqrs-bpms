using MediatR;
using Application.Ticket.Models;

namespace Application.Ticket.Queries.FindById
{
    public class FindTicketByIdQuery : IRequest<TicketInfo>
    {
        public int Id { get; set; }
    }
}
