using AutoMapper;
using MediatR;
using Infrastructure.Persistance.Repositories;
using Application.BankApplication.Models;
using Application.Common;
using Domain.Resources;

namespace Application.BankApplication.Queries.FindAll
{
    public class FindAllBankQueryHandler : IRequestHandler<FindAllBankQuery, FindAllQueryResponse<IList<BankInfo>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        
        public FindAllBankQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<FindAllQueryResponse<IList<BankInfo>>> Handle(FindAllBankQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.BankRepository.FindAll(queryFilter);
                var result = model.Item1.Select(_mapper.Map<Domain.Bank, BankInfo>).ToList();

                return FindAllQueryResponse<IList<BankInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<BankInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}
