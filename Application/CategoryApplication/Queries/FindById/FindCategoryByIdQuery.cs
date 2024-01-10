using Application.CategoryApplication.Models;
using MediatR;

namespace Application.CategoryApplication.Queries.FindById
{
    public class FindCategoryByIdQuery : IRequest<CategoryInfo>
    {
        public int Id { get; set; }
    }
}
