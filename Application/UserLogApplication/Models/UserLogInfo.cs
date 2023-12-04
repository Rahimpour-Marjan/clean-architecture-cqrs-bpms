
using Application.Users.Models;
using Domain.Enums;

namespace Application.UserLogApplication.Models
{
    public class UserLogInfo
    {
        public UserInfo User { get; set; }
        public UserLogType Type { get; set; }
        public string IP { get; set; }
        public string Device { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
