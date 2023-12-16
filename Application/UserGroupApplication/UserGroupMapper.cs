using AutoMapper;
using Application.UserGroup.Models;

namespace Application.UserGroup
{
    internal class MenuMapper : Profile
    {
        public MenuMapper()
        {
            CreateMap<Domain.UserGroup, UserGroupInfo>();
        }
    }
}
