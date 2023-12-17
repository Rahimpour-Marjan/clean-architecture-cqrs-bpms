using Domain.Enums;

namespace Domain
{
    public class Package
    {
        protected Package() { }

        public Package(string title, PackageType type, string code, bool isActive, long price, long? discount, string? imageUrl,DateTime? expireDate, DateTime modifiedDate)
        {
            Title = title;
            Type = type;
            Code = code;
            IsActive = isActive;
            Price = price;
            Discount = discount;
            ImageUrl = imageUrl;
            ExpireDate = expireDate;
            ModifiedDate = modifiedDate;
            CreateDate = DateTime.Now;
        }
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