using Application.ArticleApplication.Models;
using Application.Common;
using MediatR;

namespace Application.ArticleApplication.Queries.FindAll
{
    public class FindAllArticleQuery : IRequest<FindAllQueryResponse<IList<ArticleInfo>>>
    {
        public string? Query { get; set; }
    }
}
