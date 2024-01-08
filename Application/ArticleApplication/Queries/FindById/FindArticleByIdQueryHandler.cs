using Application.ArticleApplication.Models;
using AutoMapper;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.ArticleApplication.Queries.FindById
{
    class FindArticleByIdQueryHandler : IRequestHandler<FindArticleByIdQuery, ArticleInfo>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public FindArticleByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<ArticleInfo> Handle(FindArticleByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _uow.ArticleRepository.FindById(request.Id);
            return _mapper.Map<Domain.Article, ArticleInfo>(model);
        }
    }
}
