using AutoMapper;
using Application.UserLogApplication.Models;
using Domain;

namespace Application.UserLogApplication
{
    internal class UserLogMapper : Profile
    {
        public UserLogMapper()
        {
            CreateMap<UserLog, UserLogInfo>();
        }
    }
}
