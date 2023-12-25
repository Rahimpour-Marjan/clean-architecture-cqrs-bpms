using Application.Common;
using Application.SitePage.Models;
using AutoMapper;
using Domain.Resources;
using Infrastructure.Persistance.Repositories;
using MediatR;
using System.Data;

namespace Application.SitePage.Queries.FindAll
{
    internal class FindAllSitePageQueryHandler : IRequestHandler<FindAllSitePageQuery, FindAllQueryResponse<IList<SitePageInfo>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public FindAllSitePageQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<FindAllQueryResponse<IList<SitePageInfo>>> Handle(FindAllSitePageQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.SitePageRepository.FindAll(queryFilter);
                var result = model.Item1.Select(_mapper.Map<Domain.SitePage, SitePageInfo>).ToList();

                return FindAllQueryResponse<IList<SitePageInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<SitePageInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}
