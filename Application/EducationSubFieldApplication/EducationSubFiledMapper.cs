using AutoMapper;
using Application.EducationSubFieldApplication.Models;

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
