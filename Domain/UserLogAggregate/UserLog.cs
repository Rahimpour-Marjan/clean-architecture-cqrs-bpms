using Domain.Enums;

namespace Domain
{
    public class UserLog
    {
        protected UserLog() { }

        public UserLog(UserLogType type, string iP, string device, int creatorId)
        {
            Type = type;
            IP = iP;
            Device = device;
            CreatorId = creatorId;
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }
        public UserLogType Type { get; set; }
        public string IP { get; set; }
        public string Device { get; set; }
        public virtual User Creator { get; set; }
        public int CreatorId { get; set; }
        public int? ModifireId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
