namespace Domain.Common
{
    public class FilterResponse
    {
        public int Start { get; set; }
        public int Length { get; set; }
        public int TotalRecords { get; set; }
        public IList<FilterResponseData> Data { get; set; }
    }
    public class FilterResponseData
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
