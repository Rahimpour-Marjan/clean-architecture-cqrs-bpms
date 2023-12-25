using Application.Common;
using Application.Post.Models;
using MediatR;

namespace Application.Post.Queries.FindAll
{
    public class FindAllPostQuery : IRequest<FindAllQueryResponse<IList<PostInfo>>>
    {
        public int? ParentId { get; set; }
        public string? Query { get; set; }
    }
}
