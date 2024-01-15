using Application.ProductCategoryApplication.Models;
using AutoMapper;
using Domain;

namespace Application.ProductCategoryApplication
{
    internal class ProductCategoryMapper : Profile
    {
        public ProductCategoryMapper()
        {
            CreateMap<ProductCategory, ProductCategoryInfo>();
        }
    }
}
