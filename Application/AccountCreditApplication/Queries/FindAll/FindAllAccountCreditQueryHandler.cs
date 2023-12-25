using AutoMapper;
using MediatR;
using Infrastructure.Persistance.Repositories;
using Application.AccountCreditApplication.Models;
using Application.Common;
using Domain.Resources;

namespace Application.AccountCreditApplication.Queries.FindAll
{
    public class FindAllAccountCreditQueryHandler : IRequestHandler<FindAllAccountCreditQuery, FindAllQueryResponse<IList<AccountCreditInfo>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        
        public FindAllAccountCreditQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<FindAllQueryResponse<IList<AccountCreditInfo>>> Handle(FindAllAccountCreditQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.AccountCreditRepository.FindAll(queryFilter);
                var result = model.Item1.Select(_mapper.Map<Domain.AccountCredit, AccountCreditInfo>).ToList();

                return FindAllQueryResponse<IList<AccountCreditInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<AccountCreditInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}
