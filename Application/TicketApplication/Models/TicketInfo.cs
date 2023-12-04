using Application.Users.Models;
using Domain;
using Domain.Enums;
using Domain.Values;

namespace Application.Ticket.Models
{
    public class TicketInfo
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int? TicketParentId { get; set; }
        public string TicketText { get; set; }
        public UserInfo TicketCreator { get; set; }
        public int? WorkRequestId { get; set; }
        public TicketStatus Status { get; set; }
        public TicketPriority TicketPriority { get; set; }
        public TicketType TicketType { get; set; }
        public DateTime TicketCreateDate { get; set; }
        public List<TicketInfo> TicketChilds { get; set; }
        public List<TicketAttachmentInfo> TicketAttachments { get; set; }
    }
}
