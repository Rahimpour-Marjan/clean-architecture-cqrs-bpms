namespace Domain
{
    public class Bank
    {
        protected Bank() { }

        public Bank(string title, bool isActive, string? imageUrl, int creatorId)
        {
            Title = title;
            IsActive = isActive;
            ImageUrl = imageUrl;
            CreatorId = creatorId;
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public string? ImageUrl { get; set; }
        public int CreatorId { get; set; }
        public int? ModifireId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}