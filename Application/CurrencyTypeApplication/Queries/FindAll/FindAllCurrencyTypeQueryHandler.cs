using AutoMapper;
using MediatR;
using Infrastructure.Persistance.Repositories;
using Application.CurrencyTypeApplication.Models;
using Application.Common;
using Domain.Resources;

namespace Application.CurrencyTypeApplication.Queries.FindAll
{
    public class FindAllCurrencyTypeQueryHandler : IRequestHandler<FindAllCurrencyTypeQuery, FindAllQueryResponse<IList<CurrencyTypeInfo>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        
        public FindAllCurrencyTypeQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<FindAllQueryResponse<IList<CurrencyTypeInfo>>> Handle(FindAllCurrencyTypeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.CurrencyTypeRepository.FindAll(queryFilter);
                var result = model.Item1.Select(_mapper.Map<Domain.CurrencyType, CurrencyTypeInfo>).ToList();

                return FindAllQueryResponse<IList<CurrencyTypeInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<CurrencyTypeInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}
