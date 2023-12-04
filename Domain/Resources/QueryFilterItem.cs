using Domain.Enums;

namespace Domain.Resources
{
    public class QueryFilterItem
    {
        public string? ColumnName { get; set; }    
        public string? SearchText { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int[]? Filter { get; set; }
        public bool? Blank { get; set; }
        public ConditionType? ConditionType { get; set; }
    }
}
