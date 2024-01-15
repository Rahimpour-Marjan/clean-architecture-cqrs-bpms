using Application.ProductTypeApplication.Models;
using MediatR;

namespace Application.ProductTypeApplication.Queries.FindById
{
    public class FindProductTypeByIdQuery : IRequest<ProductTypeInfo>
    {
        public int Id { get; set; }
    }
}
