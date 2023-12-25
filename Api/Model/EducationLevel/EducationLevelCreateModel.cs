using System.ComponentModel.DataAnnotations;
namespace Api.Model.EducationLevel
{
    public class EducationLevelCreateModel
    {
        [Required(ErrorMessage = "ارسال نام اجباری می باشد")]
        public string Title { get; set; }
    }
}
