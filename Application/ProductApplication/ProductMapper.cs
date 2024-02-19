using Application.ProductApplication.Models;
using AutoMapper;
using Domain;

namespace Application.ProductApplication
{
    internal class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductInfo>();
        }
    }
}
