using Application.Common;
using Application.UnitApplication.Models;
using AutoMapper;
using Domain.Resources;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.UnitApplication.Queries.FindAll
{
    class FindAllUnitHandler : IRequestHandler<FindAllUnitQuery, FindAllQueryResponse<IList<UnitInfo>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public FindAllUnitHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<FindAllQueryResponse<IList<UnitInfo>>> Handle(FindAllUnitQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.UnitRepository.FindAll(queryFilter);
                var result = model.Item1.Select(_mapper.Map<Domain.Unit, UnitInfo>).ToList();

                return FindAllQueryResponse<IList<UnitInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<UnitInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}
