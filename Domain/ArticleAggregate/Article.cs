
namespace Domain
{
    public class Article
    {
        protected Article() { }

        public Article(string title, int categoryId, string? keywords, string summary, string body, int visitCount, bool? isSlider, bool active, string? url, string? h1, string? writer,
            string? writerPosition, string? writerImageUrl,string? aparat, string? canonical, bool? noFollow, bool? noIndex, string? postLabel, string? imageUrl,
            DateTime? showDateTime, DateTime? expireDateTime, int creatorId)
        {
            Title = title;
            CategoryId = categoryId;
            Keywords = keywords;
            Summary = summary;
            Body = body;
            VisitCount = visitCount;
            IsSlider = isSlider;
            Active = active;
            Url = url;
            H1 = h1;
            Writer = writer;
            WriterPosition = writerPosition;
            WriterImageUrl = writerImageUrl;
            Aparat = aparat;
            Canonical = canonical;
            NoFollow = noFollow;
            NoIndex = noIndex;
            PostLabel = postLabel;
            ImageUrl = imageUrl;
            ShowDateTime = showDateTime;
            ExpireDateTime = expireDateTime;
            CreatorId = creatorId;
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
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
        public int CreatorId { get; set; }
        public int? ModifireId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}