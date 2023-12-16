namespace Domain
{
    public class TicketAttachment
    {
        protected TicketAttachment()
        {
        }
        public TicketAttachment(string fileUrl, string title, decimal? size, int ticketId)
        {
            Title = title;
            FileUrl = fileUrl;
            Size = size;
            TicketId = ticketId;
            DateRecord = DateTime.Now;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string FileUrl { get; set; }
        public decimal? Size { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public DateTime DateRecord { get; set; }
    }
}
