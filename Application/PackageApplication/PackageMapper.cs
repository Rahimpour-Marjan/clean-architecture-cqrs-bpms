using Application.PackageApplication.Models;
using AutoMapper;
using Domain;

namespace Application.PackageApplication
{
    internal class PackageMapper : Profile
    {
        public PackageMapper()
        {
            CreateMap<Package, PackageInfo>();
        }
    }
}
