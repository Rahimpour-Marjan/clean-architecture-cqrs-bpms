using Application.CategoryApplication.Models;
using Application.Common;
using MediatR;

namespace Application.CategoryApplication.Queries.FindAll
{
    public class FindAllCategoryQuery : IRequest<FindAllQueryResponse<IList<CategoryInfo>>>
    {
        public string? Query { get; set; }
    }
}
