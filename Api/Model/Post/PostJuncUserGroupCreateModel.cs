using System.ComponentModel.DataAnnotations;
namespace Api.Model.Post
{
    public class PostJuncUserGroupCreateModel
    {
        [Required(ErrorMessage = "ارسال کد پست الزامی می باشد")]
        public int PostId { get; set; }

        [Required(ErrorMessage = "ارسال کد گروه کاربری الزامی می باشد")]
        public int[] UserGroupIds { get; set; }
    }
}
