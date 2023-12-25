using Application.EducationFieldApplication.Models;
using AutoMapper;
namespace Application.EducationField
{

    internal class EducationFieldMapper : Profile
    {
        public EducationFieldMapper()
        {

            CreateMap<Domain.EducationField, EducationFieldInfo>();
        }
    }
}
