namespace Domain
{
    public class Unit
    {
        protected Unit() { }

        public Unit(string title, string abbreviatedTitle, string? description, DateTime dateRecord)
        {
            Title = title;
            AbbreviatedTitle = abbreviatedTitle;
            Description = description;
            DateRecord = dateRecord;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string AbbreviatedTitle { get; set; }
        public string? Description { get; set; }
        public DateTime DateRecord { get; set; }
    }
}