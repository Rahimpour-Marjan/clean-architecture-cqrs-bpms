using Application.ArticleApplication.Models;
using AutoMapper;
using Domain;

namespace Application.ArticleApplication
{
    internal class ArticleMapper : Profile
    {
        public ArticleMapper()
        {
            CreateMap<Article, ArticleInfo>();
        }
    }
}
