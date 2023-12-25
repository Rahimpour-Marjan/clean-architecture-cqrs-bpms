using Application.EducationLevelApplication.Models;
using AutoMapper;

namespace Application.EducationLevelApplication
{
    internal class EducationLevelMapper : Profile
    {
        public EducationLevelMapper()
        {

            CreateMap<Domain.EducationLevel, EducationLevelInfo>();
        }
    }
}
