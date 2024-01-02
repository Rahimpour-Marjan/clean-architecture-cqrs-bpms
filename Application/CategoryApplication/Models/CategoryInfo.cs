
using Domain.Enums;

namespace Application.CategoryApplication.Models
{
    public class CategoryInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public CategoryType Type { get; set; }
        public bool IsActive { get; set; }
        public string? Url { get; set; }
        public string? Body { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
