using AutoMapper;
using Application.SiteActionApplication.Models;
using Application.Users.Models;

namespace Application.User
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<Domain.User, UserInfo>()
                .ForMember(dto => dto.Title, opt => opt.MapFrom(src =>
                    src.Person.FirstName + " " + src.Person.LastName))
                 .ForMember(dto => dto.Email, opt => opt.MapFrom(src =>
                    src.Person.Email));

            CreateMap<Domain.SiteAction, SiteActionInfo>();
        }
    }
}