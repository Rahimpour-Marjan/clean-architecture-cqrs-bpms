using Domain.Enums;

namespace Domain
{
    public class UserLog
    {
        protected UserLog() { }

        public UserLog(int userId, UserLogType type, string iP, string device)
        {
            UserId = userId;
            Type = type;
            IP = iP;
            Device = device;
            DateTime = System.DateTime.Now;
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public UserLogType Type { get; set; }
        public string IP { get; set; }
        public string Device { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
