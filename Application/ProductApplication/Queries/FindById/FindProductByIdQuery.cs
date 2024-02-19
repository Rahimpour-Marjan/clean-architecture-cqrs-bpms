using Application.ProductApplication.Models;
using MediatR;

namespace Application.ProductApplication.Queries.FindById
{
    public class FindProductByIdQuery : IRequest<ProductInfo>
    {
        public int Id { get; set; }
    }
}
