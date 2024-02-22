using Application.ProductCommentApplication.Models;
using MediatR;

namespace Application.ProductCommentApplication.Queries.FindById
{
    public class FindProductCommentByIdQuery : IRequest<ProductCommentInfo>
    {
        public int Id { get; set; }
    }
}
