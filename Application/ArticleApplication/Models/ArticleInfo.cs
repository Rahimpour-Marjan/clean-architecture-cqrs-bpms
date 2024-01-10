
using Application.CategoryApplication.Models;

namespace Application.ArticleApplication.Models
{
    public class ArticleInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public CategoryInfo Category { get; set; }
        public string? Keywords { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public int VisitCount { get; set; }
        public bool? IsSlider { get; set; }
        public bool Active { get; set; }
        public string? Url { get; set; }
        public string? H1 { get; set; }
        public string? Writer { get; set; }
        public string? WriterPosition { get; set; }
        public string? WriterImageUrl { get; set; }
        public string? Aparat { get; set; }
        public string? Canonical { get; set; }
        public bool? NoFollow { get; set; }
        public bool? NoIndex { get; set; }
        public string? PostLabel { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? ShowDateTime { get; set; }
        public DateTime? ExpireDateTime { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
