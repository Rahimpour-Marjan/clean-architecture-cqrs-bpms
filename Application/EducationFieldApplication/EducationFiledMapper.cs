using AutoMapper;
using Application.EducationFieldApplication.Models;
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
