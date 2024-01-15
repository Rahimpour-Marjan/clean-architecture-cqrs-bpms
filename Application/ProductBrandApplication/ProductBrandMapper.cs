using Application.ProductBrandApplication.Models;
using AutoMapper;
using Domain;

namespace Application.ProductBrandApplication
{
    internal class ProductBrandMapper : Profile
    {
        public ProductBrandMapper()
        {
            CreateMap<ProductBrand, ProductBrandInfo>();
        }
    }
}
