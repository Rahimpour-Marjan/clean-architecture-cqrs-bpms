using Application.ProductCommentApplication.Models;
using Application.Common;
using MediatR;

namespace Application.ProductCommentApplication.Queries.FindAll
{
    public class FindAllProductCommentQuery : IRequest<FindAllQueryResponse<IList<ProductCommentInfo>>>
    {
        public string? Query { get; set; }
    }
}
