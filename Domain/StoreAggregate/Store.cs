namespace Domain
{
    public class Store
    {
        protected Store() { }

        public Store(string title, int accountId,int countryId, int stateId, int cityId, int zoneId, string address, string? locationLat, string? locationLong, string code, string? zipCode, string? postalCode, string? imageUrl, int creatorId)
        {
            Title = title;
            AccountId = accountId;
            CountryId = countryId;
            StateId = stateId;
            CityId = cityId;
            ZoneId = zoneId;
            Address = address;
            LocationLat = locationLat;
            LocationLong = locationLong;
            Code = code;
            ZipCode = zipCode;
            PostalCode = postalCode;
            ImageUrl = imageUrl;
            CreatorId = creatorId;
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public int AccountId { get; set; }
        public virtual Account Account { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public int StateId { get; set; }
        public virtual State State { get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }

        public int? ZoneId { get; set; }
        public virtual Zone? Zone { get; set; }

        public string Address { get; set; }
        public string? LocationLong { get; set; }
        public string? LocationLat { get; set; }
        public string Code { get; set; }
        public string? ZipCode { get; set; }
        public string? PostalCode { get; set; }
        public string? ImageUrl { get; set; }
        public int CreatorId { get; set; }
        public int? ModifireId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }

    }
}