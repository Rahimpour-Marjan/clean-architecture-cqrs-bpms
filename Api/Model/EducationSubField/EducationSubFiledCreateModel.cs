using System.ComponentModel.DataAnnotations;
namespace Api.Model.EducationSubField
{
    public class EducationSubFieldCreateModel
    {
        [Required(ErrorMessage = "ارسال نام اجباری می باشد")]
        public string Title { get; set; }

        [Required(ErrorMessage = "انتخاب رشته تحصیلی الزامی می باشد")]
        public int EducationFieldId { get; set; }
    }
}