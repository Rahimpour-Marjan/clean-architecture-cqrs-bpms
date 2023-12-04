using AutoMapper;
using Application.Person.Models;

namespace Application.Person
{
    internal class PersonMapper : Profile
    {
        public PersonMapper()
        {
            CreateMap<Domain.Person, PersonInfo>()
                 .ForMember(dto => dto.Title, opt => opt.MapFrom(src =>
                    src.FirstName + " " + src.LastName));
        }
    }
}
