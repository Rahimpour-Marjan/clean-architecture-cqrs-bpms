using Application.Common;
using Application.ZoneApplication.Models;
using AutoMapper;
using Domain.Resources;
using Infrastructure.Persistance.Repositories;
using MediatR;

namespace Application.ZoneApplication.Queries.FindAll
{
    public class FindAllZoneQueryHandler : IRequestHandler<FindAllZoneQuery, FindAllQueryResponse<IList<ZoneInfo>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public FindAllZoneQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<FindAllQueryResponse<IList<ZoneInfo>>> Handle(FindAllZoneQuery request, CancellationToken cancellationToken)
        {
            try
            {
                QueryFilter? queryFilter = null;
                if (request.Query != null)
                    queryFilter = QueryFilterResponse.Response(request.Query);

                var model = await _uow.ZoneRepository.FindAll(queryFilter);
                var result = model.Item1.Select(_mapper.Map<Domain.Zone, ZoneInfo>).ToList();

                return FindAllQueryResponse<IList<ZoneInfo>>
                            .BuildSuccessResult(result, model.Item2, queryFilter?.PageSize, queryFilter?.PageNumber);
            }
            catch (Exception ex)
            {
                var exResult = FindAllQueryResponse<IList<ZoneInfo>>.BuildFailure(ex);
                return exResult;
            }
        }
    }
}
