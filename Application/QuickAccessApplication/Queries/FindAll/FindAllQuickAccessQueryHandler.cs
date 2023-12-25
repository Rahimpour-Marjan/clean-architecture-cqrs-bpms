using Application.Common;
using Application.QuickAccess.Models;
using AutoMapper;
using Domain.Resources;
using Infrastructure.Persistance.Repositories;
using MediatR;
using System.Data;

namespace Application.QuickAccess.Queries.FindAll
{
    public class FindAllQuickAccessQueryHandler : IRequestHandler<FindAllQuickAccessQuery, FindAllQueryResponse<IList<QuickAccessInfo>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public FindAllQuickAccessQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<FindAllQueryResponse<IList<QuickAccessInfo>>> Handle(FindAllQuickAccessQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.QuickAccessRepository.FindAll(queryFilter, request.UserId);
                var result = model.Item1.Select(_mapper.Map<Domain.QuickAccess, QuickAccessInfo>).ToList();

                return FindAllQueryResponse<IList<QuickAccessInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<QuickAccessInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}