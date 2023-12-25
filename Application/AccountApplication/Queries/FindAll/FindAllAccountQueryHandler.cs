using Application.Common;
using AutoMapper;
using Domain.Resources;
using Infrastructure.Persistance.Repositories;
using MediatR;
using System.Data;

namespace Application.Account.Queries.FindAll
{
    public class FindAllAccountQueryHandler : IRequestHandler<FindAllAccountQuery, FindAllQueryResponse<IList<Models.AccountView>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public FindAllAccountQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<FindAllQueryResponse<IList<Models.AccountView>>> Handle(FindAllAccountQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.AccountRepository.FindAll(queryFilter);
                var result = model.Item1.Select(_mapper.Map<Domain.AccountView, Models.AccountView>).ToList();

                return FindAllQueryResponse<IList<Models.AccountView>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<Models.AccountView>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}
