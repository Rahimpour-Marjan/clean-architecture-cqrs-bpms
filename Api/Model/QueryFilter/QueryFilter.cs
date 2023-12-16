namespace Api.Model.QueryFilter
{
    public class QueryFilter
    {
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public QueryFilter()
        {
            this.SortBy = "id";
            this.IsSortAscending = false;
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        public QueryFilter(string sortBy, bool isSortAscending,int pageNumber, int pageSize)
        {
            this.SortBy = sortBy;
            this.IsSortAscending = isSortAscending;
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}
