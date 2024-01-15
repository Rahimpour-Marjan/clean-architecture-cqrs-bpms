using Application.ProductBrandApplication.Models;
using MediatR;

namespace Application.ProductBrandApplication.Queries.FindById
{
    public class FindProductBrandByIdQuery : IRequest<ProductBrandInfo>
    {
        public int Id { get; set; }
    }
}
