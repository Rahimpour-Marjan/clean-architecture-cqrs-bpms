namespace Domain
{
    public class CalendarAttachment
    {
        protected CalendarAttachment()
        {
        }
        public CalendarAttachment(int calendarId, byte[] file)
        {
            CalendarId = calendarId;
            File = file;
        }
        public int Id { get; set; }
        public int CalendarId { get; set; }
        public virtual Calendar Calendar { get; set; }
        public byte[] File { get; set; }
    }
}
