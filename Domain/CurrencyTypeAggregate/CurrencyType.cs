namespace Domain
{
    public class CurrencyType
    {
        protected CurrencyType() { }

        public CurrencyType(string title, string currencySign, long unitPrice, string? imageUrl, int creatorId)
        {
            Title = title;
            CurrencySign = currencySign;
            UnitPrice = unitPrice;
            ImageUrl = imageUrl;
            CreatorId = creatorId;
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string CurrencySign { get; set; }
        public long UnitPrice { get; set; }
        public string? ImageUrl { get; set; }
        public int CreatorId { get; set; }
        public int? ModifireId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<CreditPayment> CreditPayments { get; set; }
    }
}