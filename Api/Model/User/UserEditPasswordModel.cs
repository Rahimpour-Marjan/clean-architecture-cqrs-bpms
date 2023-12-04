using System.ComponentModel.DataAnnotations;


namespace Api.Model.User
{
    public class UserEditPasswordModel
    {
        [Required(ErrorMessage = "ارسال پسورد فعلی ضروری می باشد")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "ارسال پسورد ضروری می باشد")]
        public string Password { get; set; }
    }
}
