using Application.ProductApplication.Models;
using Application.Common;
using MediatR;

namespace Application.ProductApplication.Queries.FindAll
{
    public class FindAllProductQuery : IRequest<FindAllQueryResponse<IList<ProductInfo>>>
    {
        public string? Query { get; set; }
    }
}
