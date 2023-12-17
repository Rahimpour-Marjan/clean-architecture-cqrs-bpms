namespace Domain
{
    public class City
    {
        protected City() { }

        public City(string title, int stateId, string code, string? zipCode, string? postalCode, string? locationLat, string? locationLong, string? imageUrl, DateTime modifiedDate)
        {
            Title = title;
            StateId = stateId;
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
        public int StateId { get; set; }
        public State State { get; set; }
        public string Code { get; set; }
        public string? ZipCode { get; set; }
        public string? PostalCode { get; set; }
        public string? LocationLat { get; set; }
        public string? LocationLong { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}