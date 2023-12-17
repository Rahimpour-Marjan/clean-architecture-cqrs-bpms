
using Domain.Enums;

namespace Application.PackageApplication.Models
{
    public class PackageInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public PackageType Type { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public long Price { get; set; }
        public long? Discount { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? ExpireDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
