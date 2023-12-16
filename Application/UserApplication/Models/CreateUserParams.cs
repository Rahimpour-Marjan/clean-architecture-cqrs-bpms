using Domain.Values;
using Application.Person.Models;

namespace Application.Users.Models
{
    public class CreateUserParam
    {
        public BasicInformation BasicInformation { get; set; }
        public UserConfiguration UserConfiguration { get; set; }
    }
    public class BasicInformation
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Domain { get; set; }
        public string ContactEmail { get; set; }
        public string Password { get; set; }
        public Organizations Organizations { get; set; }
    }
    public class Organizations
    {
        public int Organization { get; set; }
    }
    public class UserConfiguration
    {
        public List<CreateUserRoleParams> Roles { get; set; }
        public CreateUserAreaParam IdArea { get; set; }
        public CreateLocationParam IdLocation { get; set; }
        public CreatePositionParam Positions { get; set; }
        public int Enabled { get; set; }
        public int EnabledForAssignation { get; set; }
    }

    public class CreateUserRoleParams
    {
        public int Key { get; set; }
        public bool KeySpecified { get; set; }
    }

    public class CreateUserAreaParam
    {
        public int Key { get; set; }
        public bool KeySpecified { get; set; }
    }

    public class CreateLocationParam
    {
        public int Key { get; set; }
        public bool KeySpecified { get; set; }
    }
    public class CreatePositionParam
    {
        public int Position { get; set; }
    }
}
