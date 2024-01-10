namespace Domain
{
    public class TicketAttachment
    {
        protected TicketAttachment()
        {
        }
        public TicketAttachment(string fileUrl, string title, decimal? size, int ticketId, int creatorId)
        {
            Title = title;
            FileUrl = fileUrl;
            Size = size;
            TicketId = ticketId;
            CreatorId = creatorId;
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string FileUrl { get; set; }
        public decimal? Size { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public int CreatorId { get; set; }
        public int? ModifireId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
