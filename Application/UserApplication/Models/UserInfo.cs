using Domain.Values;
using Application.Account.Models;
using Domain.Enums;

namespace Application.Users.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public string? Post { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public UserType? UserType { get; set; }
        public AccountInfo Account { get; set; }
    }
}
