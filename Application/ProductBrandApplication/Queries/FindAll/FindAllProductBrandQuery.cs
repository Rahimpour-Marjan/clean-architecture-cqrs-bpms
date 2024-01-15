using Application.ProductBrandApplication.Models;
using Application.Common;
using MediatR;

namespace Application.ProductBrandApplication.Queries.FindAll
{
    public class FindAllProductBrandQuery : IRequest<FindAllQueryResponse<IList<ProductBrandInfo>>>
    {
        public string? Query { get; set; }
    }
}
