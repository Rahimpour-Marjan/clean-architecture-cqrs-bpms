using Application.UserGroup.Models;
using AutoMapper;

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
