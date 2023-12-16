using MediatR;
using Application.Ticket.Models;
using Application.Common;

namespace Application.Ticket.Queries.FindAll
{
    public class FindAllTicketQuery : IRequest<FindAllQueryResponse<IList<TicketInfo>>>
    {
        public int UserId { get; set; }
        public string? Query { get; set; }
    }
}
