using System.ComponentModel.DataAnnotations;

namespace Api.Model.AccountAddress
{
    public class AccountAddressInfoModel
    {
        [Required(ErrorMessage = "ارسال کد کاربر الزامی می باشد")]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "ارسال عنوان الزامی می باشد")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ارسال نام کامل الزامی می باشد")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "ارسال تلفن الزامی می باشد")]
        public string Phone { get; set; }
        public string? ExtraPhone { get; set; }

        [Required(ErrorMessage = "ارسال کد کشور الزامی می باشد")]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "ارسال کد استان الزامی می باشد")]
        public int StateId { get; set; }

        [Required(ErrorMessage = "ارسال کد شهر الزامی می باشد")]
        public int CityId { get; set; }
        public int? ZoneId { get; set; }

        [Required(ErrorMessage = "ارسال آدرس الزامی می باشد")]
        public string Address { get; set; }
        public string? ZipCode { get; set; }

        [Required(ErrorMessage = "ارسال کد پستی الزامی می باشد")]
        public string PostalCode { get; set; }
        public string? LocationLat { get; set; }
        public string? LocationLong { get; set; }
    }
}
