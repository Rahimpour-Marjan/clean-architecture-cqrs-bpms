using Application.AccountCheckApplication.Models;
using Application.Common;
using AutoMapper;
using Domain.Resources;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.AccountCheckApplication.Queries.FindAll
{
    public class FindAllAccountCheckQueryHandler : IRequestHandler<FindAllAccountCheckQuery, FindAllQueryResponse<IList<AccountCheckInfo>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public FindAllAccountCheckQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<FindAllQueryResponse<IList<AccountCheckInfo>>> Handle(FindAllAccountCheckQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.AccountCheckRepository.FindAll(queryFilter);
                var result = model.Item1.Select(_mapper.Map<Domain.AccountCheck, AccountCheckInfo>).ToList();

                return FindAllQueryResponse<IList<AccountCheckInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<AccountCheckInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}
