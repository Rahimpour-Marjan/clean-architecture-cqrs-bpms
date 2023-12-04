using System.ComponentModel.DataAnnotations;


namespace Api.Model.User
{
    public class UserEditModel
    {
        [Required(ErrorMessage = "ارسال نام کاربری ضروری می باشد")]
        public string UserName { get; set; }

        //[Required(ErrorMessage = "ارسال ایمیل ضروری می باشد")]
        //public string Email { get; set; }

        [Required(ErrorMessage = "ارسال وضعیت ضروری می باشد")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "انتخاب کاربر ضروری می باشد")]
        public int PersonId { get; set; }
    }
}
