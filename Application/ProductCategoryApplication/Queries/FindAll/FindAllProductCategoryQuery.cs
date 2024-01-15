using Application.ProductCategoryApplication.Models;
using Application.Common;
using MediatR;

namespace Application.ProductCategoryApplication.Queries.FindAll
{
    public class FindAllProductCategoryQuery : IRequest<FindAllQueryResponse<IList<ProductCategoryInfo>>>
    {
        public string? Query { get; set; }
    }
}
