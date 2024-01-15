using Domain.Enums;

namespace Domain
{
    public class Category
    {
        protected Category() { }

        public Category(string title, int? categoryParentId, CategoryType type, bool isActive, string? url, string? body, string? imageUrl,int creatorId)
        {
            Title = title;
            CategoryParentId = categoryParentId;
            Type = type;
            IsActive = isActive;
            Url = url;
            Body = body;
            ImageUrl = imageUrl;
            CreatorId= creatorId;
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public int? CategoryParentId { get; set; }
        public virtual Category? CategoryParent { get; set; }
        public CategoryType Type { get; set; }
        public bool IsActive { get; set; }
        public string? Url { get; set; }
        public string? Body { get; set; }
        public string? ImageUrl { get; set; }
        public int CreatorId { get; set; }
        public int? ModifireId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}