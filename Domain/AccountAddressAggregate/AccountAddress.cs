namespace Domain
{
    public class AccountAddress
    {
        protected AccountAddress() { }

        public AccountAddress(int AccountId, string title, string fullName, string phone, string extraPhone, int countryId,
            int stateId, int cityId, int? zoneId, string address, string zipCode, string postalCode, string? locationLat, string? locationLong,int creatorId)
        {
            AccountId = AccountId;
            Title = title;
            FullName = fullName;
            Phone = phone;
            ExtraPhone = extraPhone;
            CountryId = countryId;
            StateId = stateId;
            CityId = cityId;
            ZoneId = zoneId;
            Address = address;
            ZipCode = zipCode;
            PostalCode = postalCode;
            LocationLat = locationLat;
            LocationLong = locationLong;
            CreatorId = creatorId;
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        public string Title { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string ExtraPhone { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public int StateId { get; set; }
        public virtual State State { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public int? ZoneId { get; set; }
        public virtual Zone? Zone { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string PostalCode { get; set; }
        public string? LocationLat { get; set; }
        public string? LocationLong { get; set; }
        public int CreatorId { get; set; }
        public int? ModifireId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}