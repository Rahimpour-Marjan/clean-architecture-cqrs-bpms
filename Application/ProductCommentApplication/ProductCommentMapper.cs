using Application.ProductCommentApplication.Models;
using AutoMapper;
using Domain;

namespace Application.ProductCommentApplication
{
    internal class ProductCommentMapper : Profile
    {
        public ProductCommentMapper()
        {
            CreateMap<ProductComment, ProductCommentInfo>();
        }
    }
}
