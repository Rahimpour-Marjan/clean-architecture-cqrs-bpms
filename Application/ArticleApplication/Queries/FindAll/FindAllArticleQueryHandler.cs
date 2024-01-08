using Application.ArticleApplication.Models;
using Application.Common;
using AutoMapper;
using Domain.Resources;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.ArticleApplication.Queries.FindAll
{
    public class FindAllArticleQueryHandler : IRequestHandler<FindAllArticleQuery, FindAllQueryResponse<IList<ArticleInfo>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public FindAllArticleQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<FindAllQueryResponse<IList<ArticleInfo>>> Handle(FindAllArticleQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.ArticleRepository.FindAll(queryFilter);
                var result = model.Item1.Select(_mapper.Map<Domain.Article, ArticleInfo>).ToList();

                return FindAllQueryResponse<IList<ArticleInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<ArticleInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}
