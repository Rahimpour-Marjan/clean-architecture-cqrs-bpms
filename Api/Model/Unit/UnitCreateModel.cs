using System.ComponentModel.DataAnnotations;

namespace Api.Model.Unit
{
    public class UnitCreateModel
    {
        [Required(ErrorMessage = "ارسال نام الزامی می باشد")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ارسال نام اختصاری الزامی می باشد")]
        public string AbbreviatedTitle { get; set; }
        public string? Description { get; set; }
    }
}
