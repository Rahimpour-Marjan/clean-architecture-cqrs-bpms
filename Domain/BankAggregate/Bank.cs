namespace Domain
{
    public class Bank
    {
        protected Bank() { }

        public Bank(string title, bool isActive, string? imageUrl, DateTime modifiedDate)
        {
            Title = title;
            IsActive = isActive;
            ImageUrl = imageUrl;
            ModifiedDate = modifiedDate;
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}