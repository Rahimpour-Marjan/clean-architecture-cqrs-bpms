namespace Domain
{
    public class CalendarReceiver
    {
        public CalendarReceiver(int calendarId, int receiverId)
        {
            CalendarId = calendarId;
            ReceiverId = receiverId;
        }

        protected CalendarReceiver()
        {
        }

        public int Id { get; set; }
        public int CalendarId { get; set; }
        public virtual Calendar Calendar { get; set; }
        public int ReceiverId { get; set; }
        public virtual Account Account { get; set; }
    }
}
