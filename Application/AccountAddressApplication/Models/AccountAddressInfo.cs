
using Application.CityApplication.Models;
using Application.CountryApplication.Models;
using Application.Account.Models;
using Application.StateApplication.Models;
using Application.ZoneApplication.Models;

namespace Application.AccountAddressApplication.Models
{
    public class AccountAddressInfo
    {
        public int Id { get; set; }
        public AccountInfo Account { get; set; }
        public string Title { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string ExtraPhone { get; set; }
        public CountryInfo Country { get; set; }
        public StateInfo State { get; set; }
        public CityInfo City { get; set; }
        public ZoneInfo Zone { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string PostalCode { get; set; }
        public string? LocationLat { get; set; }
        public string? LocationLong { get; set; }
    }
}
