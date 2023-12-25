using Application.UserLogApplication.Models;
using AutoMapper;
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
