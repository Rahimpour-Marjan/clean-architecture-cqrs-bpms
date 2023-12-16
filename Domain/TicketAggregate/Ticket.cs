using Domain.Enums;

namespace Domain
{
    public class Ticket
    {
        public Ticket(string title, string code, int? ticketParentId, string ticketText, int ticketCreatorId,int? workRequestId, TicketStatus status,TicketPriority ticketPriority, TicketType ticketType)
        {
            Title = title;
            Code = code;
            TicketParentId= ticketParentId;
            TicketText = ticketText;
            TicketCreatorId = ticketCreatorId;
            Status = status;
            TicketPriority = ticketPriority;
            TicketType = ticketType;
            TicketCreateDate = DateTime.Now;
        }
        protected Ticket()
        {
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int? TicketParentId { get; set; }
        public Ticket? TicketParent { get; set; }
        public string TicketText { get; set; }
        public int TicketCreatorId { get; set; }
        public  User TicketCreator { get; set; }
        public TicketStatus Status { get; set; }
        public TicketPriority TicketPriority { get; set; }
        public TicketType TicketType { get; set; }
        public DateTime TicketCreateDate { get; set; }
        public virtual ICollection<TicketAttachment> TicketAttachments { get; set; }
        public virtual ICollection<Ticket> TicketChilds { get; set; }
    }
}
