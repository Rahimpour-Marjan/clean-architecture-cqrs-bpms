using System.ComponentModel.DataAnnotations;

namespace Api.Model.Login
{
    public class LoginDto
    {
        [Required(ErrorMessage = "ارسال نام کاربری اجباری می باشد")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "ارسال رمزعبور الزامی می باشد")]
        public string Password { get; set; }
    }
}
