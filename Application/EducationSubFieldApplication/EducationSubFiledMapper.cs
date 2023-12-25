using Application.EducationSubFieldApplication.Models;
using AutoMapper;

namespace Application.EducationSubFieldApplication
{
    internal class EducationSubFieldMapper : Profile
    {
        public EducationSubFieldMapper()
        {

            CreateMap<Domain.EducationSubField, EducationSubFieldInfo>();
        }
    }
}
