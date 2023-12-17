
using Application.StateApplication.Models;

namespace Application.CityApplication.Models
{
    public class CityInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public StateInfo State { get; set; }
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
