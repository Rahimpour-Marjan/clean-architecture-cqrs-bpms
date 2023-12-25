using AutoMapper;
using MediatR;
using Infrastructure.Persistance.Repositories;
using Application.StateApplication.Models;
using Application.Common;
using Domain.Resources;

namespace Application.StateApplication.Queries.FindAll
{
    public class FindAllStateQueryHandler : IRequestHandler<FindAllStateQuery, FindAllQueryResponse<IList<StateInfo>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        
        public FindAllStateQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<FindAllQueryResponse<IList<StateInfo>>> Handle(FindAllStateQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.StateRepository.FindAll(queryFilter);
                var result = model.Item1.Select(_mapper.Map<Domain.State, StateInfo>).ToList();

                return FindAllQueryResponse<IList<StateInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<StateInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}
