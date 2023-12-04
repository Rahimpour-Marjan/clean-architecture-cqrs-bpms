using AutoMapper;
using Application.Menu.Models;

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
