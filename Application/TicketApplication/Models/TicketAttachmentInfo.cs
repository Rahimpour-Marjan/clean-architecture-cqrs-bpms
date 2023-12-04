using Domain.Values;

namespace Application.Ticket.Models
{
    public class TicketAttachmentInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FileUrl { get; set; }
        public decimal Size { get; set; }
    }
}
