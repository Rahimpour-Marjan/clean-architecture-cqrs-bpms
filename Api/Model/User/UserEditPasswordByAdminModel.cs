using System.ComponentModel.DataAnnotations;


namespace Api.Model.User
{
    public class UserEditPasswordByAdminModel
    {

        [Required(ErrorMessage = "ارسال پسورد ضروری می باشد")]
        public string Password { get; set; }
    }
}
