using System.ComponentModel.DataAnnotations;

namespace Api.Model.CurrencyType
{
    public class CurrencyTypeInfoModel
    {
        [Required(ErrorMessage = "ارسال عنوان الزامی می باشد")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ارسال علامت واحد پولی الزامی می باشد")]
        public string CurrencySign { get; set; }

        [Required(ErrorMessage = "ارسال قیمت واحد الزامی می باشد")]
        public long UnitPrice { get; set; }
        public string? ImageUrl { get; set; }
    }
}
