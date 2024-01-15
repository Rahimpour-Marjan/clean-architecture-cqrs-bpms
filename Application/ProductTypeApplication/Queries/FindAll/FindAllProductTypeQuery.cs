using Application.ProductTypeApplication.Models;
using Application.Common;
using MediatR;

namespace Application.ProductTypeApplication.Queries.FindAll
{
    public class FindAllProductTypeQuery : IRequest<FindAllQueryResponse<IList<ProductTypeInfo>>>
    {
        public string? Query { get; set; }
    }
}
