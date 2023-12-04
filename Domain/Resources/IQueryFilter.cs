namespace Domain.Resources
{
    public interface IQueryFilter
    {
        string SortBy { get; set; }
        bool IsSortAscending { get; set; }
        int? PageNumber { get; set; }
        int? PageSize { get; set; }
    }
}