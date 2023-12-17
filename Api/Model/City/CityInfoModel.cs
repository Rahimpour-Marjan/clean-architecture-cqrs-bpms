using System.ComponentModel.DataAnnotations;

namespace Api.Model.City
{
    public class CityInfoModel
    {
        [Required(ErrorMessage = "ارسال نام الزامی می باشد")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ارسال کد استان الزامی می باشد")]
        public int StateId { get; set; }

        [Required(ErrorMessage = "ارسال کد الزامی می باشد")]
        public string Code { get; set; }
        public string? ZipCode { get; set; }
        public string? PostalCode { get; set; }
        public string? LocationLat { get; set; }
        public string? LocationLong { get; set; }
        public string? ImageUrl { get; set; }
    }
}
