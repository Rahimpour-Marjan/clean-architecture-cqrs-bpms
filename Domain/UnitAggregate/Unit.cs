namespace Domain
{
    public class Unit
    {
        protected Unit() { }

        public Unit(string title, string abbreviatedTitle, string? description, int creatorId)
        {
            Title = title;
            AbbreviatedTitle = abbreviatedTitle;
            Description = description;
            CreatorId = creatorId;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string AbbreviatedTitle { get; set; }
        public string? Description { get; set; }
        public int CreatorId { get; set; }
        public int? ModifireId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}