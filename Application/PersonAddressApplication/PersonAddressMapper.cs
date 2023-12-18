using Application.PersonAddressApplication.Models;
using AutoMapper;
using Domain;

namespace Application.PersonAddressApplication
{
    internal class PersonAddressMapper : Profile
    {
        public PersonAddressMapper()
        {
            CreateMap<PersonAddress, PersonAddressInfo>();
        }
    }
}
