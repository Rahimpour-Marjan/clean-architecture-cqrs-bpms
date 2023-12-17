using AutoMapper;
using Application.EducationLevelApplication.Models;

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
