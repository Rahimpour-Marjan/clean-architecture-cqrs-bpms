
using System.ComponentModel.DataAnnotations;

namespace Api.Model.UserGroup
{
    public class UserGroupPrivilageCreateModel
    {
        [Required(ErrorMessage = "ارسال کد گروه کاربری ضروری می باشد")]
        public int UserGroupId { get; set; }

        [Required(ErrorMessage = "ارسال لیست آیدی های منتخب ضروری می باشد")]
        public int[] Ids { get; set; }
    }
}
