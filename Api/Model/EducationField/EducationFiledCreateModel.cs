using System.ComponentModel.DataAnnotations;
namespace Api.Model.EducationField
{
    public class EducationFieldCreateModel
    {
        [Required(ErrorMessage = "ارسال نام اجباری می باشد")]
        public string Title { get; set; }
    }
}
