using Application.Menu.Models;
using AutoMapper;

namespace Application.Menu
{
    internal class MenuMapper : Profile
    {
        public MenuMapper()
        {
            CreateMap<Domain.Menu, MenuInfo>();
        }
    }
}
