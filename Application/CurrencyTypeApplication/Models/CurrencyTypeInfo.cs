
namespace Application.CurrencyTypeApplication.Models
{
    public class CurrencyTypeInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CurrencySign { get; set; }
        public double UnitPrice { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
