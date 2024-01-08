using Domain.Enums;

namespace Domain
{
    public class Category
    {
        protected Category() { }

        public Category(string title, CategoryType type, bool isActive, string? url, string? body, string? imageUrl, int ceatorId)
        {
            Title = title;
            Type = type;
            IsActive = isActive;
            Url = url;
            Body = body;
            ImageUrl = imageUrl;
            CreatorId= ceatorId;
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public CategoryType Type { get; set; }
        public bool IsActive { get; set; }
        public string? Url { get; set; }
        public string? Body { get; set; }
        public string? ImageUrl { get; set; }
        public int CreatorId { get; set; }
        public int? ModifireId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}