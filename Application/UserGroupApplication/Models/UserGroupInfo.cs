using Domain.Values;

namespace Application.UserGroup.Models
{
    public class UserGroupInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public bool IsEditable { get; set; }
        public UserGroupInfo UserGroupParent { get; set; }
    }
}
