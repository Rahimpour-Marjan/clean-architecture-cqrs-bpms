
using Domain.Enums;

namespace Domain
{
    public class User
    {
        protected User() { }

        public User(int AccountId, string userName, string password, string salt, string email, UserType userType, bool isActive, int creatorId)
        {
            AccountId = AccountId;
            UserName = userName;
            Password = password;
            Salt = salt;
            Email = email;
            UserType = userType;
            IsActive = isActive;
            CreatorId = creatorId;
            CreateDate= DateTime.Now;
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }
        public int AccountId { get; set; }
        public UserType? UserType { get; set; }
        public bool IsActive { get; set; }
        public virtual Account Account { get; set; }
        public string VerifyCode { get; set; }
        public int VerifyTryCount { get; set; }
        public DateTime? LastVerifyTryDateTime { get; set; }
        public bool MobileVerified { get; set; }
        public int CreatorId { get; set; }
        public int? ModifireId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
