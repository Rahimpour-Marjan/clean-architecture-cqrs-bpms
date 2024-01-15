using Application.ProductCategoryApplication.Models;
using MediatR;

namespace Application.ProductCategoryApplication.Queries.FindById
{
    public class FindProductCategoryByIdQuery : IRequest<ProductCategoryInfo>
    {
        public int Id { get; set; }
    }
}
