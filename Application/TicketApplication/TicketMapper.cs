using Application.Ticket.Models;
using AutoMapper;
using Domain;

namespace Application.Ticket
{
    internal class TicketMapper : Profile
    {
        public TicketMapper()
        {
            CreateMap<Domain.Ticket, TicketInfo>();

            CreateMap<TicketAttachment, TicketAttachmentInfo>();
        }
    }
}
