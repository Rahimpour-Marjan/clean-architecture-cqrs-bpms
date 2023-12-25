using AutoMapper;
using MediatR;
using Infrastructure.Persistance.Repositories;
using Application.AccountAddressApplication.Models;
using Application.Common;
using Domain.Resources;

namespace Application.AccountAddressApplication.Queries.FindAll
{
    public class FindAllAccountAddressQueryHandler : IRequestHandler<FindAllAccountAddressQuery, FindAllQueryResponse<IList<AccountAddressInfo>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        
        public FindAllAccountAddressQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<FindAllQueryResponse<IList<AccountAddressInfo>>> Handle(FindAllAccountAddressQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.AccountAddressRepository.FindAll(queryFilter);
                var result = model.Item1.Select(_mapper.Map<Domain.AccountAddress, AccountAddressInfo>).ToList();

                return FindAllQueryResponse<IList<AccountAddressInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<AccountAddressInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}
