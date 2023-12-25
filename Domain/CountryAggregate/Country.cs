namespace Domain
{
    public class Country
    {
        protected Country() { }

        public Country(string title, string code, string? zipCode, string? postalCode, string? locationLat, string? locationLong, string? imageUrl, DateTime modifiedDate)
        {
            Title = title;
            Code = code;
            ZipCode = zipCode;
            PostalCode = postalCode;
            LocationLat = locationLat;
            LocationLong = locationLong;
            ImageUrl = imageUrl;
            ModifiedDate = modifiedDate;
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string? ZipCode { get; set; }
        public string? PostalCode { get; set; }
        public string? LocationLat { get; set; }
        public string? LocationLong { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<State> States { get; set; }
    }
}