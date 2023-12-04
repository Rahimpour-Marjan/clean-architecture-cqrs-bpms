using System.ComponentModel.DataAnnotations;
namespace Api.Model.Post
{
    public class PostCreateModel
    {
        [Required(ErrorMessage = "ارسال نام برای پست الزامی می باشد")]
        public string Title { get; set; }
        public int? ParentId { get; set; }
    }
}
