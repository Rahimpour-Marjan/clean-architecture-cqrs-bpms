using AutoMapper;
using MediatR;
using Domain;
using Infrastructure.Persistance.Repositories;
using Application.SiteActionApplication.Models;
using Application.Common;
using Domain.Resources;

namespace Application.SiteActionApplication.Queries.FindAll
{
    class FindAllSiteActionHandler : IRequestHandler<FindAllSiteActionQuery, FindAllQueryResponse<IList<SiteActionInfo>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        
        public FindAllSiteActionHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<FindAllQueryResponse<IList<SiteActionInfo>>> Handle(FindAllSiteActionQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.SiteActionRepository.FindAll(queryFilter);
                var result = model.Item1.Select(_mapper.Map<SiteAction, SiteActionInfo>).ToList();

                return FindAllQueryResponse<IList<SiteActionInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<SiteActionInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}
