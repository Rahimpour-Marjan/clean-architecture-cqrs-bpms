using Application.CategoryApplication.Models;
using AutoMapper;
using Domain;

namespace Application.CategoryApplication
{
    internal class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, CategoryInfo>();
        }
    }
}
