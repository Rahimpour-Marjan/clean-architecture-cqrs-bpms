using Domain.Enums;

namespace Domain
{
    public class Ticket
    {
        public Ticket(string title, string code, int? ticketParentId, string ticketText, int ticketCreatorId, int? workRequestId, TicketStatus status, TicketPriority ticketPriority, TicketType ticketType, int creatorId)
        {
            Title = title;
            Code = code;
            TicketParentId = ticketParentId;
            TicketText = ticketText;
            TicketCreatorId = ticketCreatorId;
            Status = status;
            TicketPriority = ticketPriority;
            TicketType = ticketType;
            CreatorId = creatorId;
            CreateDate = DateTime.Now;
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
        public User TicketCreator { get; set; }
        public TicketStatus Status { get; set; }
        public TicketPriority TicketPriority { get; set; }
        public TicketType TicketType { get; set; }
        public int CreatorId { get; set; }
        public int? ModifireId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<TicketAttachment> TicketAttachments { get; set; }
        public virtual ICollection<Ticket> TicketChilds { get; set; }
    }
}
