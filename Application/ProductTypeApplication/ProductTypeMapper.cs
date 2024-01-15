using Application.ProductTypeApplication.Models;
using AutoMapper;
using Domain;

namespace Application.ProductTypeApplication
{
    internal class ProductTypeMapper : Profile
    {
        public ProductTypeMapper()
        {
            CreateMap<ProductType, ProductTypeInfo>();
        }
    }
}
