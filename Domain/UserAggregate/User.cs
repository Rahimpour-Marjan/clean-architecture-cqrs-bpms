
using Domain.Enums;

namespace Domain
{
    public class User
    {
        protected User() { }

        public User(int personId, string userName, string password, string salt, string email, UserType userType,bool isActive, int? apiResultCode)
        {
            PersonId = personId;
            UserName = userName;
            Password = password;
            Salt = salt;
            Email = email;
            UserType = userType;
            IsActive = isActive;
            ApiResultCode = apiResultCode;
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }
        public int PersonId { get; set; }
        public UserType? UserType { get; set; }
        public bool IsActive { get; set; }
        public virtual Person Person { get; set; }
        public int? ApiResultCode { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
