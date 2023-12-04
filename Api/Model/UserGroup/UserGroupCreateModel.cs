using System.ComponentModel.DataAnnotations;
namespace Api.Model.UserGroup
{
    public class UserGroupCreateModel
    {
        [Required(ErrorMessage = "ارسال عنوان اجباری می باشد")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ارسال وضعیت اجباری می باشد")]
        public bool IsActive { get; set; }
        public int? UserGroupParentId { get; set; }
    }
}
