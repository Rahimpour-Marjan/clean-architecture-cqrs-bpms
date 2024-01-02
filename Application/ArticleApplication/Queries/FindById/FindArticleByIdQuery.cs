using Application.ArticleApplication.Models;
using MediatR;

namespace Application.ArticleApplication.Queries.FindById
{
    public class FindArticleByIdQuery : IRequest<ArticleInfo>
    {
        public int Id { get; set; }
    }
}
